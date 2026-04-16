using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseno.Controllers
{
    public class ArchivosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
