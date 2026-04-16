using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProyectoDiseno.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace ProyectoDiseno.Controllers
{
    public class ClientesController : Controller
    {
        private static readonly List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Cedula = "101010101", Nombre = "Ruben", Apellido1 = "Valerin", Apellido2 = "Lopez" },
            new Cliente { Cedula = "202020202", Nombre = "Jorge", Apellido1 = "Mora", Apellido2 = "Solis" }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Json(clientes);
        }

        [HttpPost]
        public IActionResult Agregar([FromBody] Cliente nuevo)
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

            if (clientes.Any(c => c.Cedula == nuevo.Cedula))
                return BadRequest(new { mensaje = "Ya existe un cliente con esa cédula" });

            clientes.Add(nuevo);
            return Json(new { ok = true, mensaje = "Cliente guardado correctamente" });
        }

        [HttpGet]
        public IActionResult ExportarJson()
        {
            string carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data");
            Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "clientes.json");
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(ruta, json);

            return File(System.IO.File.ReadAllBytes(ruta), "application/json", $"clientes_{DateTime.Now:yyyyMMdd}.json");
        }

        [HttpGet]
        public IActionResult ExportarXml()
        {
            var xml = new XDocument(
                new XElement("clientes",
                    clientes.Select(c =>
                        new XElement("cliente",
                            new XElement("cedula", c.Cedula),
                            new XElement("nombre", c.Nombre),
                            new XElement("apellido1", c.Apellido1),
                            new XElement("apellido2", c.Apellido2)
                        )
                    )
                )
            );

            var bytes = Encoding.UTF8.GetBytes(xml.ToString());
            return File(bytes, "application/xml", $"clientes_{DateTime.Now:yyyyMMdd}.xml");
        }

        [HttpPost("ImportarJson")]
        public IActionResult ImportarJson(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("Archivo vacío.");

            using var reader = new StreamReader(archivo.OpenReadStream());
            var contenido = reader.ReadToEnd();

            var nuevosClientes = JsonSerializer.Deserialize<List<Cliente>>(contenido);

            if (nuevosClientes == null)
                return BadRequest("Error al leer el JSON.");

            foreach (var cliente in nuevosClientes)
            {
                if (!clientes.Any(c => c.Cedula == cliente.Cedula))
                    clientes.Add(cliente);
            }

            return Ok("Clientes importados desde JSON.");
        }

        [HttpPost("ImportarXml")]
        public IActionResult ImportarXml(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("Archivo vacío.");

            using var reader = new StreamReader(archivo.OpenReadStream());
            var contenido = reader.ReadToEnd();

            var xml = XDocument.Parse(contenido);

            var nuevosClientes = xml.Descendants("cliente")
                .Select(c => new Cliente
                {
                    Cedula = c.Element("cedula")?.Value,
                    Nombre = c.Element("nombre")?.Value,
                    Apellido1 = c.Element("apellido1")?.Value,
                    Apellido2 = c.Element("apellido2")?.Value
                }).ToList();

            foreach (var cliente in nuevosClientes)
            {
                if (!clientes.Any(c => c.Cedula == cliente.Cedula))
                    clientes.Add(cliente);
            }

            return Ok("Clientes importados desde XML.");
        }
    }
}