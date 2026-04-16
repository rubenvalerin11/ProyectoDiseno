using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseno.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
