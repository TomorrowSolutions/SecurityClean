using Microsoft.AspNetCore.Mvc;

namespace SecurityClean3.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult SimpleError(string errorMessage)
        {
            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }
    }
}
