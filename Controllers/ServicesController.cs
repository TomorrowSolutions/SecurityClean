using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;

namespace SecurityClean3.Controllers
{
    public class ServicesController : Controller
    {
        private readonly SecurityContext _context;

        public ServicesController(SecurityContext context)
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
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";
            if (searchString!=null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var services = from s in _context.Services select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                services= services.Where(s=>
                s.Name.Contains(searchString)||
                s.Price.ToString().Contains(searchString)
                );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    services = services.OrderByDescending(s => s.Name);
                    break;
                case "price_desc":
                    services = services.OrderByDescending(s => s.Price);
                    break;
                case "price":
                    services = services.OrderBy(s => s.Price);
                    break;
                default:
                    services = services.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 5;
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
                .ThenInclude(p=>p.Employees)
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
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                    "Попробуйте снова, если проблема сохраняется, " +
                    "обратитесь к системному администратору.");
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

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", service.PositionId);
            return View(service);
        }

        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceToUpdate = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if(await TryUpdateModelAsync<Service>(
                serviceToUpdate,
                "",
                s=>s.Name,s=>s.Price,s=>s.PositionId)) 
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                        "Попробуйте снова, если проблема сохраняется, " +
                        "обратитесь к системному администратору.");
                }
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", serviceToUpdate.PositionId);
            return View(serviceToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
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
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Не удалось запись. " +
                    "Попробуйте снова, если проблема сохраняется, " +
                    "обратитесь к системному администратору.";
            }
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }            
        }

        private bool ServiceExists(int id)
        {
          return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
