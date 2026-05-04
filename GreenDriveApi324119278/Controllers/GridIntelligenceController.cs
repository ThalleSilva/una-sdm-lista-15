using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDriveApi324119278.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenDriveApi324119278.Controllers
{
    [ApiController]
    [Route("api/intelligence")]
    public class GridIntelligenceController : ControllerBase
    {
         private readonly AppDbContext _context;

        public GridIntelligenceController(AppDbContext context)
        {
            _context = context;
        }

         [HttpGet("carbon-footprint")]
        public IActionResult GetCarbonFootprint()
        {
            
            Task.Delay(2000);

            var resultado =  _context.OrdensReciclagem
                .Include(o => o.EstacaoCarga)
                .GroupBy(o => o.EstacaoCarga!.Localizacao)
                .Select(g => new
                {
                    Cidade = g.Key,
                    CustoTotal = g.Sum(x => x.CustoProcessamento)
                })
                .ToListAsync();

            return Ok(resultado);
        }
    }
}