using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;
using System.Diagnostics.Contracts;

namespace SecurityClean3.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SecurityContext _context;

        public EmployeesController(SecurityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PositionSortParm"] = string.IsNullOrEmpty(sortOrder) ? "position_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var tmp = _context.Employees.Include(e => e.Position);
            var employees = from p in tmp select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e =>
                    e.FullName.Contains(searchString) ||
                    e.Position.Name.Contains(searchString)
                );
            }
            switch (sortOrder)
            {
                case "position_desc":
                    employees = employees.OrderByDescending(e => e.Position.Name);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Position.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Employee>.CreateAsync(employees.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Position)
                .ThenInclude(p=>p.Services)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,HireDate,Education,PositionId")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employee);
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
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", employee.PositionId);
            return View(employee);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                                        .Include(e=>e.Position)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(e=>e.Id==id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", employee.PositionId);
            return View(employee);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeToUpdate = await _context.Employees.FirstOrDefaultAsync(e => e.Id==id);
            if (employeeToUpdate==null)
            {
                Employee deletedEmployee = new Employee();
                await TryUpdateModelAsync(deletedEmployee);
                ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Запись удалена другим пользователем");
                ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", employeeToUpdate.PositionId);
                return View(deletedEmployee);
            }
            _context.Entry(employeeToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync<Employee>(
                    employeeToUpdate,
                    "",
                    e=>e.FullName,e=>e.HireDate,e=>e.Education, e => e.PositionId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Employee)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Запись удалена другим пользователем");
                    }
                    else
                    {
                        var databaseValues = (Employee)databaseEntry.ToObject();
                        if (databaseValues.FullName != clientValues.FullName)
                        {
                            ModelState.AddModelError("FullName", $"Актуальное значение: {databaseValues.FullName}");
                        }

                        if (databaseValues.HireDate != clientValues.HireDate)
                        {
                            ModelState.AddModelError("HireDate", $"Актуальное значение: {databaseValues.HireDate:d}");
                        }

                        if (databaseValues.Education != clientValues.Education)
                        {
                            ModelState.AddModelError("Education", $"Актуальное значение: {databaseValues.Education}");
                        }

                        if (databaseValues.PositionId != clientValues.PositionId)
                        {
                            var positionFromDb = await _context.Positions.FirstOrDefaultAsync(x => x.Id == databaseValues.PositionId);
                            ModelState.AddModelError("PositionId", $"Актуальное значение: {positionFromDb?.Name}");
                        }
                        ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                        "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                        "Если вы все еще хотите внести измененные значения то нажмите 'Отправить' или можете вернуться назад к списку всех записей.");
                        employeeToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", employeeToUpdate.PositionId);
            return View(employeeToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Position)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                        "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                        "Если вы все еще хотите удалить то нажмите 'Удалить' или можете вернуться назад к списку всех записей.";
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Employee employee)
        {
            try
            {
                if (await _context.Employees.AnyAsync(e=>e.Id==employee.Id))
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = employee.Id });
            }
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
