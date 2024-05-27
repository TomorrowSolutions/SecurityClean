using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPOI.HPSF;
using NPOI.XWPF.UserModel;
using SecurityClean3.Data;
using SecurityClean3.Models;
using SecurityClean3.Utils;
using System.Text;

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


        public async Task<IActionResult> Index()
        {
            var securityContext = _context.Contracts.Include(c => c.Customer).AsNoTracking();
            return View(await securityContext.ToListAsync());
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
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            if (contract.IsLocked)
            {
                return Problem("Договор заблокирован(не может быть изменен)");
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson", contract.CustomerId);
            return View(contract);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,SignDate,StartDate,EndDate,IsLocked")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "ContactPerson", contract.CustomerId);
            return View(contract);
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contracts == null)
            {
                return Problem("Entity set 'SecurityContext.Contracts'  is null.");
            }
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null)
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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                var errorMessage = "Не удалось создать документ, так как договор заблокирован (документ должен быть уже создан)";
                return RedirectToAction("SimpleError", "Error", new { errorMessage }); 
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
                contract.IsLocked = true;
                string fileName=DocFiller.FillTemplate(contract.Customer, contract, contract.ContractServices.Select(x => x.Service).ToList(), contract.ContractSecuredItems.Select(x => x.SecuredItem).ToList(), _env);
                contract.FileName = fileName;
                await _context.SaveChangesAsync();
            }            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ClearDoc(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract != null&&contract.IsLocked)
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
                return Problem("Не удалось скачать файл, так как договор не заблокирован");
            }
            
            
            return Problem("Не удалось скачать файл");
        }


        private bool ContractExists(int id)
        {
            return (_context.Contracts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
