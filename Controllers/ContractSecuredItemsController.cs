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
    public class ContractSecuredItemsController : Controller
    {
        private readonly SecurityContext _context;

        public ContractSecuredItemsController(SecurityContext context)
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
            var tmp = _context.ContractSecuredItems
                .Include(c => c.Contract)
                .Include(c => c.SecuredItem);
            var items = from i in tmp select i;
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.ContractId.ToString().Contains(searchString));
            }
            int pageSize = 5;
            return View(await PaginatedList<ContractSecuredItem>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractSecuredItem = await _context.ContractSecuredItems
                .Include(c => c.Contract)
                .Include(c => c.SecuredItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractSecuredItem == null)
            {
                return NotFound();
            }

            return View(contractSecuredItem);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id");
            ViewData["SecuredItemId"] = new SelectList(_context.SecuredItems, "Id", "Address");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,SecuredItemId")] ContractSecuredItem item)
        {
            try
            {
                if (await _context.ContractSecuredItems.AnyAsync(i => i.ContractId == item.ContractId && i.SecuredItemId == item.SecuredItemId))
                {
                    ModelState.AddModelError(string.Empty, Resources.General.Errors.CombinationExists);

                }
                if (ModelState.IsValid)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, Resources.General.Errors.Generic);
            }           
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id", item.ContractId);
            ViewData["SecuredItemId"] = new SelectList(_context.SecuredItems, "Id", "Address", item.SecuredItemId);
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractSecuredItem = await _context.ContractSecuredItems
                .Include(i=>i.Contract).FirstOrDefaultAsync(x=>x.Id==id);
            if (contractSecuredItem == null)
            {
                return NotFound();
            }
            if (contractSecuredItem.Contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.LockedDetails });
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id", contractSecuredItem.ContractId);
            ViewData["SecuredItemId"] = new SelectList(_context.SecuredItems, "Id", "Address", contractSecuredItem.SecuredItemId);
            return View(contractSecuredItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id ==null)
            {
                return NotFound();
            }
            var itemToUpdate = await _context.ContractSecuredItems.FindAsync(id);
            if (itemToUpdate==null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
            }
            _context.Entry(itemToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync<ContractSecuredItem>(
                    itemToUpdate,
                    "",
                    i => i.ContractId, i => i.SecuredItemId))
            {
                if (await _context.ContractSecuredItems.AnyAsync(i => i.ContractId == itemToUpdate.ContractId && i.SecuredItemId == itemToUpdate.SecuredItemId))
                {
                    ModelState.AddModelError(string.Empty, Resources.General.Errors.CombinationExists);
                    ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", itemToUpdate.ContractId);
                    ViewData["SecuredItemId"] = new SelectList(_context.SecuredItems, "Id", "Address", itemToUpdate.SecuredItemId);
                    return View(itemToUpdate);
                }
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (ContractSecuredItem)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
                    }
                    else
                    {
                        var databaseValues = (ContractSecuredItem)databaseEntry.ToObject();
                        if (databaseValues.ContractId != clientValues.ContractId)
                        {
                            var contractFromDb = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == databaseValues.ContractId);
                            ModelState.AddModelError("ContractId", $"Актуальное значение: {contractFromDb?.Id}");
                        }
                        if (databaseValues.SecuredItemId != clientValues.SecuredItemId)
                        {
                            var securedItemFromDb = await _context.SecuredItems.FirstOrDefaultAsync(x => x.Id == databaseValues.SecuredItemId);
                            ModelState.AddModelError("SecuredItemId", $"Актуальное значение: {securedItemFromDb?.Address}");
                        }
                        ModelState.AddModelError(string.Empty,Resources.General.Errors.Concurrency);
                        itemToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }  
            }

            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", itemToUpdate.ContractId);
            ViewData["SecuredItemId"] = new SelectList(_context.SecuredItems, "Id", "Address", itemToUpdate.SecuredItemId);
            return View(itemToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractSecuredItem = await _context.ContractSecuredItems
                .Include(c => c.Contract)
                .Include(c => c.SecuredItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractSecuredItem == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (contractSecuredItem.Contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.LockedDetails });
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = Resources.General.Errors.Concurrency;
            }
            return View(contractSecuredItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ContractSecuredItem item)
        {
            try
            {
                if (await _context.ContractSecuredItems.AnyAsync(i => i.Id == item.Id))
                {
                    _context.ContractSecuredItems.Remove(item);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = item.Id });
            }
        }

        private bool ContractSecuredItemExists(int id)
        {
            return _context.ContractSecuredItems.Any(e => e.Id == id);
        }
    }
}
