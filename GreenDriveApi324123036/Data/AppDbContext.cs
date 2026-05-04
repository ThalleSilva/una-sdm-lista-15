using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenDriveApi324119278.Model;
using Microsoft.EntityFrameworkCore;

namespace GreenDriveApi324119278.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bateria> Baterias { get; set; }
        public DbSet<EstacaoCarga> EstacoesCarga { get; set; }
        public DbSet<RegistroTelemetria> RegistrosTelemetria { get; set; }
        public DbSet<OrdemReciclagem> OrdensReciclagem { get; set; }
    }
}