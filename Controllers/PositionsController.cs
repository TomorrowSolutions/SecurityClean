using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;
using System.Data;

namespace SecurityClean3.Controllers
{
    public class PositionsController : Controller
    {
        private readonly SecurityContext _context;

        public PositionsController(SecurityContext context)
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
            var positions = from p in _context.Positions select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                positions = positions.Where(p =>
                    p.Name.Contains(searchString) ||
                    p.Wage.ToString().Contains(searchString)
                );
            }
            int pageSize = 5;
            return View(await PaginatedList<Position>.CreateAsync(positions.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p => p.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Wage")] Position position)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(position);
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

            return View(position);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.Include(p => p.Employees).FirstOrDefaultAsync(p => p.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var positionToUpdate = await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);
            if (positionToUpdate == null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = "Не удалось сохранить изменения. Запись удалена другим пользователем" });
            }
            _context.Entry(positionToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Position>(
                positionToUpdate,
                "",
                p => p.Name, p => p.Wage))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Position)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Запись удалена другим пользователем");
                    }
                    else
                    {
                        var databaseValues = (Position)databaseEntry.ToObject();
                        if (databaseValues.Name != clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
                        }
                        if (databaseValues.Wage != clientValues.Wage)
                        {
                            ModelState.AddModelError("Wage", $"Current value: {databaseValues.Wage}");
                        }
                        ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                        "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                        "Если вы все еще хотите внести измененные значения то нажмите 'Отправить' или можете вернуться назад к списку всех записей.");
                        positionToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            return View(positionToUpdate);
        }


        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.Include(p => p.Employees)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
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

            return View(position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Position position)
        {
            try
            {
                if (await _context.Positions.AnyAsync(p => p.Id == position.Id))
                {
                    _context.Positions.Remove(position);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = position.Id });
            }
        }
    }
}
