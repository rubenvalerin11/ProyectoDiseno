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

public class ClientesController : Controller
{
    private static readonly List<Cliente> clientes = new List<Cliente>
    {
        new Cliente { Cedula = "101010101", Nombre = "Ruben", Apellido1 = "Valerin", Apellido2 = "Lopez" },
        new Cliente { Cedula = "202020202", Nombre = "Jorge", Apellido1 = "Mora", Apellido2 = "Solis" }
    };

    // ... ( métodos actuales)

    [HttpGet("ExportarXml")]
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

    //  agregar clientes nuevos (SIN crear otra clase)

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