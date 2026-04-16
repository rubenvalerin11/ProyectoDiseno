using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseno.Controllers
{
    public class ClientesPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
