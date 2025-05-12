using Microsoft.AspNetCore.Mvc;

namespace TrApp.RestApi.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
