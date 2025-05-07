using Microsoft.AspNetCore.Mvc;

namespace TrApp.RestApi.Controllers
{
    
    [Route("/")]   
    public class HomeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
