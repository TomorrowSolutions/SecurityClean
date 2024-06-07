using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;

namespace SecurityClean3.Controllers
{
    public class SecuredItemsController : Controller
    {
        private readonly SecurityContext _context;

        public SecuredItemsController(SecurityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
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
            var items = from i in _context.SecuredItems select i;
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(i =>
                    i.Name.Contains(searchString)||
                    i.Address.Contains(searchString)
                );
            }
            int pageSize = 5;
            return View(await PaginatedList<SecuredItem>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1,pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securedItem = await _context.SecuredItems
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (securedItem == null)
            {
                return NotFound();
            }

            return View(securedItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] SecuredItem securedItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(securedItem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                                    "Попробуйте снова, если проблема сохраняется, " +
                                    "обратитесь к системному администратору.");
            }            
            return View(securedItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securedItem = await _context.SecuredItems.FindAsync(id);
            if (securedItem == null)
            {
                return NotFound();
            }
            return View(securedItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemToUpdate = await _context.SecuredItems.FindAsync(id);
            if (itemToUpdate==null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = "Не удалось сохранить изменения. Запись удалена другим пользователем" });
            }
            _context.Entry(itemToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync<SecuredItem>(
                itemToUpdate,
                string.Empty,
                i => i.Name, i => i.Address
                ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (SecuredItem)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Запись удалена другим пользователем");
                    }
                    else
                    {
                        var databaseValues = (SecuredItem)databaseEntry.ToObject();
                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }
                        if (databaseValues.Address != clientValues.Address)
                        {
                            ModelState.AddModelError("Address", $"Current value: {databaseValues.Address}");
                        }
                        ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                       "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                       "Если вы все еще хотите внести измененные значения то нажмите 'Отправить' или можете вернуться назад к списку всех записей.");
                        itemToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            return View(itemToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securedItem = await _context.SecuredItems
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (securedItem == null)
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

            return View(securedItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SecuredItem item)
        {
            try
            {
                if (await _context.SecuredItems.AnyAsync(s => s.Id == item.Id))
                {
                    _context.SecuredItems.Remove(item);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = item.Id });
            }
        }
    }
}
