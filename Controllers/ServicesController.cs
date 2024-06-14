using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;
using SecurityClean3.Utils;

namespace SecurityClean3.Controllers
{
    [Authorize(Roles = $"{Roles.Admin}")]
    public class ServicesController : Controller
    {
        private readonly SecurityContext _context;

        public ServicesController(SecurityContext context)
        {
            _context = context;
        }

        //На вход поступают три параметра 
        //search string отвечает за текущую поисковый запрос
        //current filter необходим для сохранения поискового запроса при переходе по страницам
        //page number содержит номер текущей страницы
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            //Проверка строки поиска на null
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            //Передача поисковой строки в качестве фильтра для страниц
            ViewData["CurrentFilter"] = searchString;
            var services = from s in _context.Services select s;
            //поиск по заданным полям
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s =>
                s.Name.Contains(searchString) ||
                s.Price.ToString().Contains(searchString)
                );
            }
            //Количество записей на странице
            int pageSize = 5;
            //Возврат нового PaginatedList
            return View(await PaginatedList<Service>.CreateAsync(services.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Position)
                .ThenInclude(p => p.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }


        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,PositionId")] Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(service);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty,Resources.General.Errors.Generic);
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", service.PositionId);
            return View(service);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                                        .Include(s => s.Position)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            bool isContractLocked = await _context.Contracts
                                   .Include(c => c.ContractServices)
                                   .AnyAsync(c => c.IsLocked && c.ContractServices.Any(csi => csi.ServiceId == id));
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", service.PositionId);
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            //Проверка id на null
            if (id == null)
            {
                return NotFound();
            }
            //Получение записи
            var serviceToUpdate = await _context.Services
                                        .Include(s => s.Position)
                                        .FirstOrDefaultAsync(s => s.Id == id);
            //Проверка записи на null
            //Если запись равна null, то это значит, что она была удалена во время изменения и смысла отправлять форму обратно уже нет.
            //Происходит переход в контроллер ошибок с указанием, что запись была удалена
            if (serviceToUpdate == null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
            }
            //Подстановка значения полученного с формы, которое может отличаться от значений из БД
            _context.Entry(serviceToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            //Обновление модели
            if (await TryUpdateModelAsync<Service>(
                serviceToUpdate,
                "",
                s => s.Name, s => s.Price, s => s.PositionId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //Отлов исключения если версии строк не совпадают
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Service)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();                    
                    if (databaseEntry == null)
                    {
                        return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
                    }
                    else
                    {
                        var databaseValues = (Service)databaseEntry.ToObject();
                        //Вывод актуальных значений на форму в виде ошибок модели
                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Актуальное значение: {databaseValues.Name}");
                        }

                        if (databaseValues.Price != clientValues.Price)
                        {
                            ModelState.AddModelError("Price", $"Актуальное значение: {databaseValues.Price}");
                        }

                        if (databaseValues.PositionId != clientValues.PositionId)
                        {
                            var positionFromDb = await _context.Positions.FirstOrDefaultAsync(p => p.Id == databaseValues.PositionId);
                            ModelState.AddModelError("PositionId", $"Актуальное значение: {positionFromDb?.Name}");
                        }
                        //Вывод сообщения о состоянии параллелизма в виде ошибки модели
                        ModelState.AddModelError(string.Empty, Resources.General.Errors.Concurrency);
                        //Обновление свойства rowVersion
                        serviceToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", serviceToUpdate.PositionId);
            return View(serviceToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)//Получаем состояние ошибки в виде параметра метода
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Position)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                //Если возникает состояние конкуренции в данном случае значит удаление уже было проведено
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            //Здесь состояние конкуренции говорит о том, что другой пользователь изменил данные о записи
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = Resources.General.Errors.Concurrency;
            }
            bool isContractLocked = await _context.Contracts
                                   .Include(c => c.ContractServices)
                                   .AnyAsync(c => c.IsLocked && c.ContractServices.Any(csi => csi.ServiceId == id));
            if (isContractLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.LockedDetails });
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Service service)
        {
            //Попытка удаления 
            try
            {
                //Проверка существования записи с таким id
                if (await _context.Services.AnyAsync(x => x.Id == service.Id))
                {
                    _context.Services.Remove(service);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            //В случае если не получилось обновить запись отправляет форму обратно с сообщением об ошибке
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = service.Id });
            }
        }
    }
}
