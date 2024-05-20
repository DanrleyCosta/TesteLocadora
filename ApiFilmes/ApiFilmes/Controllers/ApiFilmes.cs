using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers
{
    public class ApiFilmes : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
