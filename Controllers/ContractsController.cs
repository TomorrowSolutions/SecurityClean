using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Data;
using SecurityClean3.Models;
using SecurityClean3.Utils;

namespace SecurityClean3.Controllers
{
    public class ContractsController : Controller
    {
        private readonly SecurityContext _context;
        private readonly IWebHostEnvironment _env;

        public ContractsController(SecurityContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            var tmp = _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.ContractServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContractSecuredItems)
                .ThenInclude(c => c.SecuredItem);
            var contracts = from c in tmp select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                contracts = contracts.Where(c => c.Customer.ContactPerson.Contains(searchString));
            }
            int pageSize = 5;
            return View(await PaginatedList<Contract>.CreateAsync(contracts.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.ContractServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContractSecuredItems)
                .ThenInclude(c => c.SecuredItem)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }


        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,SignDate,StartDate,EndDate,IsLocked")] Contract contract)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(contract);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, Resources.General.Errors.Generic);
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson", contract.CustomerId);
            return View(contract);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.Include(c => c.Customer).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            if (contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.ContractLocked });
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson", contract.CustomerId);
            return View(contract);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contractToUpdate = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
            if (contractToUpdate == null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
            }
            _context.Entry(contractToUpdate).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync<Contract>(
                contractToUpdate,
                "",
                c => c.SignDate, c => c.StartDate, c => c.EndDate, c => c.CustomerId, c => c.IsLocked
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
                    var clientValues = (Contract)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.AlreadyDeleted });
                    }
                    else
                    {

                        var databaseValues = (Contract)databaseEntry.ToObject();
                        if (databaseValues.CustomerId != clientValues.CustomerId)
                        {
                            Customer customerFromDb = await _context.Customers.FirstOrDefaultAsync(c => c.Id == databaseValues.CustomerId);
                            ModelState.AddModelError("CustomerId", $"Актуальное значение: {customerFromDb?.ContactPerson}");
                        }

                        if (databaseValues.SignDate != clientValues.SignDate)
                        {
                            ModelState.AddModelError("SignDate", $"Актуальное значение: {databaseValues.SignDate:d}");
                        }

                        if (databaseValues.StartDate != clientValues.StartDate)
                        {
                            ModelState.AddModelError("StartDate", $"Актуальное значение: {databaseValues.StartDate:d}");
                        }

                        if (databaseValues.EndDate != clientValues.EndDate)
                        {
                            ModelState.AddModelError("EndDate", $"Актуальное значение: {databaseValues.EndDate:d}");
                        }

                        if (databaseValues.IsLocked != clientValues.IsLocked)
                        {
                            ModelState.AddModelError("IsLocked", $"Актуальное значение: {databaseValues.IsLocked}");
                        }
                        ModelState.AddModelError("", Resources.General.Errors.Concurrency);
                        contractToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson", contractToUpdate.CustomerId);
            return View(contractToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                 .Include(c => c.Customer)
                .Include(c => c.ContractServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContractSecuredItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = Resources.General.Errors.Concurrency;
            }
            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Contract contract)
        {
            try
            {
                if (await _context.Contracts.AnyAsync(c => c.Id == contract.Id))
                {
                    try
                    {
                        System.IO.File.Delete(DocFiller.GetOutputPath(_env, contract.FileName));
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                    }
                    _context.Contracts.Remove(contract);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = contract.Id });
            }
        }

        public async Task<IActionResult> CreateDoc(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.ContractServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContractSecuredItems)
                .ThenInclude(c => c.SecuredItem)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract.IsLocked)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.DocumentAlready });
            }
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }
        [HttpPost, ActionName("CreateDoc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDocConfirmed(int id)
        {
            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .Include(c => c.ContractServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContractSecuredItems)
                .ThenInclude(c => c.SecuredItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract != null)
            {
                if (contract.IsLocked)
                {
                    return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.DocumentAlready });
                }
                contract.IsLocked = true;
                string fileName = DocFiller.FillTemplate(contract.Customer, contract, contract.ContractServices.Select(x => x.Service).ToList(), contract.ContractSecuredItems.Select(x => x.SecuredItem).ToList(), _env);
                contract.FileName = fileName;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearDoc(int id)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
            if (contract != null && contract.IsLocked)
            {
                contract.IsLocked = false;
                try
                {
                    System.IO.File.Delete(DocFiller.GetOutputPath(_env, contract.FileName));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
                contract.FileName = null;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DownloadDoc(int? id)
        {
            if (id == null || _context.Contracts == null)
            {
                return NotFound();
            }
            var contract = await _context.Contracts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            if (contract.IsLocked)
            {
                try
                {
                    if (contract.IsLocked)
                    {
                        if (!string.IsNullOrEmpty(contract.FileName))
                        {
                            string contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                            return File(DocFiller.GetOutputRelativePath(contract.FileName), contentType, contract.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            else
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.ContractUnlocked });
            }
            return RedirectToAction("SimpleError", "Error", new { errorMessage = Resources.General.Errors.Download });
        }
    }
}
