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
        public class EstacaoCargaController:ControllerBase
    {
      private readonly AppDbContext _context;

        public EstacaoCargaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar(EstacaoCarga estacao)
        {
            _context.EstacoesCarga.Add(estacao);
            _context.SaveChanges();
            return Ok(estacao);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.EstacoesCarga.ToList());
        } 
    }
}