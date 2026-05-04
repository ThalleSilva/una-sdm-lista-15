using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDriveApi324119278.Data;
using GreenDriveApi324119278.Model;
using Microsoft.AspNetCore.Mvc;

namespace GreenDriveApi324119278.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroTelemetriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistroTelemetriaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.RegistrosTelemetria.ToList());
        }


        [HttpPost]
        public IActionResult Criar(RegistroTelemetria registro)
        {
            var bateria = _context.Baterias.Find(registro.BateriaId);

            if (bateria == null)
                return BadRequest("Bateria não encontrada.");


            if (registro.Temperatura > 85)
            {
                Console.WriteLine($"ALERTA DE SEGURANÇA: Risco térmico detectado na bateria {bateria.NumeroSerie}!");
                return BadRequest("Temperatura acima do limite permitido.");
            }

            _context.RegistrosTelemetria.Add(registro);
            _context.SaveChanges();

            return Ok(registro);
        }

    }
}