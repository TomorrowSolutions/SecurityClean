using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;
using SecurityClean3.Utils;

namespace SecurityClean3.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager}")]
    public class ContractServicesController : Controller
    {
        private readonly SecurityContext _context;

        public ContractServicesController(SecurityContext context)
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
            var tmp = _context.ContractServices.Include(c => c.Contract).Include(c => c.Service);
            var items = from i in tmp select i;
            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => 
                i.ContractId.ToString().Contains(searchString)||
                i.Service.Name.Contains(searchString)
                );
            }
            int pageSize = 5;
            return View(await PaginatedList<ContractService>.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractService = await _context.ContractServices
                .Include(c => c.Contract)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractService == null)
            {
                return NotFound();
            }

            return View(contractService);
        }

        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContractId,ServiceId,RowVersion")] ContractService item)
        {
            try
            {
                if (await _context.ContractServices.AnyAsync(i => i.ContractId == item.ContractId && i.ServiceId == item.ServiceId))
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
                ModelState.AddModelError("", Resources.General.Errors.Generic);
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id", item.ContractId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", item.ServiceId);
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractService = await _context.ContractServices.Include(i => i.Contract).FirstOrDefaultAsync(x => x.Id == id); ;
            if (contractService == null)
            {
                return NotFound();
            }
            if (contractService.Contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.LockedDetails });
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts.Where(x => x.IsLocked == false), "Id", "Id", contractService.ContractId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", contractService.ServiceId);
            return View(contractService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemToUpdate = await _context.ContractServices.FindAsync(id);
            if (itemToUpdate == null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
            }
            _context.Entry(itemToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync<ContractService>(
                    itemToUpdate,
                    "",
                    i => i.ContractId, i => i.ServiceId))
            {
                if (await _context.ContractServices.AnyAsync(i => i.ContractId == itemToUpdate.ContractId && i.ServiceId == itemToUpdate.ServiceId))
                {
                    ModelState.AddModelError(string.Empty, Resources.General.Errors.CombinationExists);
                    ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", itemToUpdate.ContractId);
                    ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", itemToUpdate.ServiceId);
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
                    var clientValues = (ContractService)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
                    }
                    else
                    {
                        var databaseValues = (ContractService)databaseEntry.ToObject();
                        if (databaseValues.ContractId != clientValues.ContractId)
                        {
                            var contractFromDb = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == databaseValues.ContractId);
                            ModelState.AddModelError("ContractId", $"Актуальное значение: {contractFromDb?.Id}");
                        }
                        if (databaseValues.ServiceId != clientValues.ServiceId)
                        {
                            var serviceFromDb = await _context.Services.FirstOrDefaultAsync(x => x.Id == databaseValues.ServiceId);
                            ModelState.AddModelError("ServiceId", $"Актуальное значение: {serviceFromDb?.Name}");
                        }
                        ModelState.AddModelError(string.Empty, Resources.General.Errors.Concurrency);
                        itemToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["ContractId"] = new SelectList(_context.Contracts, "Id", "Id", itemToUpdate.ContractId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", itemToUpdate.ServiceId);
            return View(itemToUpdate);
        }
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractService = await _context.ContractServices
                .Include(c => c.Contract)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractService == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (contractService.Contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.LockedDetails });
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = Resources.General.Errors.Concurrency;
            }

            return View(contractService);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ContractService item)
        {
            try
            {
                if (await _context.ContractServices.AnyAsync(i => i.Id == item.Id))
                {
                    _context.ContractServices.Remove(item);
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
