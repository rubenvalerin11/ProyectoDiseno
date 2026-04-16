using Microsoft.AspNetCore.Mvc;
using ProyectoDiseno.Models;
using System.Text.Json;
using System.Xml.Serialization;

namespace ProyectoDiseno.Controllers
{
    public class ClientesPageController : Controller
    {
        private static List<Cliente> listaClientes = new List<Cliente>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Json(listaClientes);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Cliente nuevo)
        {
            if (nuevo == null)
                return BadRequest(new { mensaje = "Cliente nulo" });

            if (string.IsNullOrWhiteSpace(nuevo.Cedula) ||
                string.IsNullOrWhiteSpace(nuevo.Nombre) ||
                string.IsNullOrWhiteSpace(nuevo.Apellido1) ||
                string.IsNullOrWhiteSpace(nuevo.Apellido2))
            {
                return BadRequest(new { mensaje = "Faltan datos" });
            }

            listaClientes.Add(nuevo);
            return Json(new { ok = true, mensaje = "Cliente guardado correctamente" });
        }

        [HttpGet]
        public IActionResult ExportarJson()
        {
            string carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
            Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "clientes.json");
            string json = JsonSerializer.Serialize(listaClientes, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(ruta, json);

            return File(System.IO.File.ReadAllBytes(ruta), "application/json", "clientes.json");
        }

        [HttpGet]
        public IActionResult ExportarXml()
        {
            string carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
            Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "clientes.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            using (var writer = new StreamWriter(ruta))
            {
                serializer.Serialize(writer, listaClientes);
            }

            return File(System.IO.File.ReadAllBytes(ruta), "application/xml", "clientes.xml");
        }
    }
}