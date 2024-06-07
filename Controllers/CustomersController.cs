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
    public class CustomersController : Controller
    {
        private readonly SecurityContext _context;

        public CustomersController(SecurityContext context)
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
            var customers = from c in _context.Customers select c;
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c =>
                c.CompanyName.Contains(searchString)||
                c.LegalAddress.Contains(searchString)||
                c.ContactPerson.Contains(searchString)
                );
            }
            int pageSize = 5;
            return View(await PaginatedList<Customer>.CreateAsync(customers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,LegalAddress,Inn,AccountNumber,Bank,Bik,CorrespondentAccount,ContactPerson")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Не удалось сохранить изменения. " +
                    "Попробуйте снова, если проблема сохраняется, " +
                    "обратитесь к системному администратору.");
            }           
            return View(customer);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customerToUpdate = await _context.Customers.FindAsync(id);
            if (customerToUpdate==null)
            {
                return RedirectToAction("SimpleError", "Error", new { errorMessage = "Не удалось сохранить изменения. Запись удалена другим пользователем" });
            }

            _context.Entry(customerToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Customer>(
                customerToUpdate,
                string.Empty,
                c=>c.CompanyName,c=>c.LegalAddress, c => c.Inn, c => c.AccountNumber, c => c.Bank, c => c.Bik, c => c.CorrespondentAccount, c => c.ContactPerson
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
                    var clientValues = (Customer)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Не удалось сохранить изменения. Запись удалена другим пользователем");
                    }
                    else
                    {
                        var databaseValues = (Customer)databaseEntry.ToObject();
                        if (databaseValues.CompanyName != clientValues.CompanyName)
                        {
                            ModelState.AddModelError("CompanyName", $"Актуальное значение: {databaseValues.CompanyName}");
                        }

                        if (databaseValues.LegalAddress != clientValues.LegalAddress)
                        {
                            ModelState.AddModelError("LegalAddress", $"Актуальное значение: {databaseValues.LegalAddress}");
                        }

                        if (databaseValues.Inn != clientValues.Inn)
                        {
                            ModelState.AddModelError("Inn", $"Актуальное значение: {databaseValues.Inn}");
                        }

                        if (databaseValues.AccountNumber != clientValues.AccountNumber)
                        {
                            ModelState.AddModelError("AccountNumber", $"Актуальное значение: {databaseValues.AccountNumber}");
                        }

                        if (databaseValues.Bank != clientValues.Bank)
                        {
                            ModelState.AddModelError("Bank", $"Актуальное значение: {databaseValues.Bank}");
                        }

                        if (databaseValues.Bik != clientValues.Bik)
                        {
                            ModelState.AddModelError("Bik", $"Актуальное значение: {databaseValues.Bik}");
                        }

                        if (databaseValues.CorrespondentAccount != clientValues.CorrespondentAccount)
                        {
                            ModelState.AddModelError("CorrespondentAccount", $"Актуальное значение: {databaseValues.CorrespondentAccount}");
                        }

                        if (databaseValues.ContactPerson != clientValues.ContactPerson)
                        {
                            ModelState.AddModelError("ContactPerson", $"Актуальное значение: {databaseValues.ContactPerson}");
                        }
                        ModelState.AddModelError("", "Запись, которую вы хотели изменить, была модифицирована другим пользователем. " +
                        "Операция была отменена и теперь вы сможете видеть поля которые были изменены. " +
                        "Если вы все еще хотите внести измененные значения то нажмите 'Отправить' или можете вернуться назад к списку всех записей.");
                        customerToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            return View(customerToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
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

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Customer customer)
        {
            try
            {
                if (await _context.Customers.AnyAsync(x=>x.Id==customer.Id))
                {
                    _context.Customers.Remove(customer);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = customer.Id });
            }            
        }
    }
}
