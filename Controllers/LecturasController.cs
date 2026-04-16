using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseno.Controllers
{
    public class LecturasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
