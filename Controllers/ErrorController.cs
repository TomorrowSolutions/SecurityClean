using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityClean3.Utils;

namespace SecurityClean3.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager}")]
    public class ErrorController : Controller
    {
        public IActionResult SimpleError(string errorMessage)
        {
            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }
    }
}
