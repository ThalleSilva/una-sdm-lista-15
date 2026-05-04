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
    public class OrdemReciclagemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdemReciclagemController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.OrdensReciclagem.ToList());
        }

         [HttpPost]
        public IActionResult Criar(OrdemReciclagem ordem)
        {
            var bateria = _context.Baterias.Find(ordem.BateriaId);
            var estacao = _context.EstacoesCarga.Find(ordem.EstacaoId);

            if (bateria == null || estacao == null)
                return BadRequest("Bateria ou Estação inválida.");

            
            if (bateria.SaudeBateria > 60)
            {
                return BadRequest("Bateria com saúde superior a 60%. Use Second Life.");
            }

            
            if (estacao.TipoCarga == "Ultra-Rapida")
            {
                ordem.CustoProcessamento += 250;
            }

            _context.OrdensReciclagem.Add(ordem);
            _context.SaveChanges();

            return Ok(ordem);
        }
    }

}