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
    public class BateriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BateriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(Bateria bateria)
        {
            _context.Baterias.Add(bateria);
            _context.SaveChanges();
            return Ok(bateria);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Baterias.ToList());
        }
         [HttpPatch("{id}/saude")]
        public IActionResult AtualizarSaude(int id, [FromBody] int novaSaude)
        {
            var bateria =  _context.Baterias.Find(id);

            if (bateria == null)
                return NotFound("Bateria não encontrada.");

            if (novaSaude < 0 || novaSaude > 100)
                return BadRequest("A saúde da bateria deve estar entre 0 e 100.");

            if (bateria.SaudeBateria <= 10 && novaSaude > bateria.SaudeBateria)
            {
                return Conflict("Fraude de dados detectada: uma bateria inativa não pode ter sua saúde aumentada.");
            }

            bateria.SaudeBateria = novaSaude;

             _context.SaveChangesAsync();

            return Ok(bateria);
        }
    }
}