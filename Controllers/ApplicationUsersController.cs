using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Models;
using SecurityClean3.Models.ViewModels;
using SecurityClean3.Utils;
using System.Security.Claims;

namespace SecurityClean3.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(
            string searchString,
            string currentFilter,
            int? pageNumber
            )
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var users = from u in _userManager.Users select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => 
                    u.FullName.Contains(searchString) ||
                    u.Email.Contains(searchString)||
                    u.UserName.Contains(searchString)
                );
            }
            int pageSize = 5;
            return View( await PaginatedList<ApplicationUser>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1,pageSize));
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }
            
            var user = await _userManager.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            UserRolesVM viewmodel = new UserRolesVM()
            {
                User = user,
                Roles = await _userManager.GetRolesAsync(user)
            };
            return View(viewmodel);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task SetUserRoleAsync(ApplicationUser user, string role)
        {
            var existingRoles = await _userManager.GetRolesAsync(user);

            // Удаляем все текущие роли пользователя
            await _userManager.RemoveFromRolesAsync(user, existingRoles.ToArray());

            // Добавляем новую роль
            await _userManager.AddToRoleAsync(user, role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName, Email, Password, IsAdmin")] RegistrationVM registrationVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userManager.Users.AnyAsync(x=>x.Email==registrationVM.Email))
                    {
                        ModelState.AddModelError("", "Пользователь с таким email уже существует.");
                        return View(registrationVM);
                    }
                    var user = new ApplicationUser()
                    {
                        FullName = registrationVM.FullName,
                        UserName = registrationVM.Email,
                        Email = registrationVM.Email
                    };
                    var result = await _userManager.CreateAsync(user, registrationVM.Password);
                    if (result.Succeeded)
                    {
                        if (registrationVM.IsAdmin)
                        {
                            await SetUserRoleAsync(user, Roles.Admin);
                        }
                        else
                        {
                            await SetUserRoleAsync(user, Roles.Manager);
                        }
                    }
                    else
                    {
                        return RedirectToAction("SimpleError", "Error", new { errorMessage = string.Join(", ",result.Errors.Select(x=>x.Description)) });
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                   "Попробуйте снова, если проблема сохраняется, " +
                   "обратитесь к системному администратору.");
            }
            return View(registrationVM);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id==id);

            if (userToUpdate == null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = "Не удалось сохранить изменения. Пользователь удален другим пользователем" });
            }

            if (!rowVersion.SequenceEqual(userToUpdate.RowVersion))
            {
                ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                              "Операция была отменена и теперь вы сможете видеть актуальные данные. " +
                              "Если вы все еще хотите обновить запись, то повторите внесенные изменения");

                // Очистка ModelState для поля RowVersion
                ModelState.Remove("RowVersion");                
                return View(userToUpdate);
            }

            // Попытка заполнения и обновления модели
            if (await TryUpdateModelAsync(userToUpdate, "",
                u => u.FullName,u=>u.Email /* Добавьте здесь другие поля, которые могут быть обновлены */))
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == userToUpdate.Email))
                {
                    ModelState.AddModelError("", "Пользователь с таким email уже существует.");
                    return View(userToUpdate);
                }
                // Обновление данных пользователя и сохранение изменений
                await _userManager.UpdateAsync(userToUpdate);

                return RedirectToAction(nameof(Index));
            }

            return View(userToUpdate);
        }
        public async Task<IActionResult> ChangePassword(string? id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }
            if (await _userManager.Users.AnyAsync(x=>x.Id==id))
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
                ChangePasswordVM vm = new ChangePasswordVM() { Id=user.Id };
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([Bind("Id,Password,ConfirmPassword")]ChangePasswordVM viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id==viewModel.Id);
                    var token=await _userManager.GeneratePasswordResetTokenAsync(userToUpdate);
                    var result = await _userManager.ResetPasswordAsync(userToUpdate, token, viewModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                           "Попробуйте снова, если проблема сохраняется, " +
                           "обратитесь к системному администратору.");
                    }                    
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                   "Попробуйте снова, если проблема сохраняется, " +
                   "обратитесь к системному администратору.");
            }
            return View(viewModel);
        }
        public async Task<IActionResult> ChangeRole(string? id)
        {
            if (id == null || _userManager.Users == null)
            {
                return NotFound();
            }
            if (await _userManager.Users.AnyAsync(x => x.Id == id))
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
                ChangeRoleVM vm = new ChangeRoleVM()  {  Id = user.Id  };
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.FirstOrDefault()==Roles.Admin)
                {
                    vm.IsAdmin = true;
                }
                else if(roles.FirstOrDefault() == Roles.Manager)
                {
                    vm.IsAdmin = false;
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole([Bind("Id,IsAdmin")] ChangeRoleVM viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
                    if (viewModel.IsAdmin)
                    {
                        await SetUserRoleAsync(userToUpdate, Roles.Admin);
                    }
                    else
                    {
                        await SetUserRoleAsync(userToUpdate, Roles.Manager);
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                       "Попробуйте снова, если проблема сохраняется, " +
                       "обратитесь к системному администратору.");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                   "Попробуйте снова, если проблема сохраняется, " +
                   "обратитесь к системному администратору.");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            if (user == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "Запись, которую вы хотели удалить, была модифицирована другим пользователем. " +
                        "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                        "Если вы все еще хотите удалить то нажмите 'Удалить' или можете вернуться назад к списку всех записей.";
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, byte[] rowVersion)
        {
            var userToDelete = await _userManager.Users.FirstAsync(x => x.Id == id);
            try
            {
                if (userToDelete!=null)
                {
                    if (!rowVersion.SequenceEqual(userToDelete.RowVersion))
                    {
                        ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                                      "Операция была отменена и теперь вы сможете видеть актуальные данные. " +
                                      "Если вы все еще хотите удалить то нажмите 'Удалить' или можете вернуться назад к списку всех записей.");
                        // Очистка ModelState для поля RowVersion
                        ModelState.Remove("RowVersion");
                        return View(userToDelete);
                    }
                    await _userManager.DeleteAsync(userToDelete);                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = userToDelete.Id });
            }
        }
    }
}
