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
    public class PositionsController : Controller
    {
        private readonly SecurityContext _context;

        public PositionsController(SecurityContext context)
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
            ViewData["CurrentSort"]= sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["WageSortParm"]= sortOrder=="Wage"? "wage_desc":"Wage";
            if (searchString!=null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString=currentFilter;
            }
            ViewData["CurrentFilter"]= searchString;
            var positions = from p in _context.Positions select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                positions = positions.Where(p => 
                    p.Name.Contains(searchString) ||
                    p.Wage.ToString().Contains(searchString)
                );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    positions = positions.OrderByDescending(p => p.Name);
                    break;
                case "wage_desc":
                    positions = positions.OrderByDescending(p => p.Wage);
                    break;
                case "Wage":
                    positions = positions.OrderBy(p => p.Wage);
                    break;
                default:
                    positions.OrderBy(p => p.Name);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Position>.CreateAsync(positions.AsNoTracking(),pageNumber ?? 1,pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .Include(p=>p.Employees)
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

            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var positionToUpdate = await _context.Positions.FirstOrDefaultAsync(p=>p.Id==id);
            if(await TryUpdateModelAsync<Position>(
                positionToUpdate,
                "",
                p=>p.Name,p=>p.Wage ))
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
            return View(positionToUpdate);
        }


        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Не удалось запись. " +
                    "Попробуйте снова, если проблема сохраняется, " +
                    "обратитесь к системному администратору.";
            }
            return View(position);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool PositionExists(int id)
        {
          return (_context.Positions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
