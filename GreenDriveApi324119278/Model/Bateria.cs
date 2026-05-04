using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenDriveApi324119278.Model
{
    public class Bateria
    {
         public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public double CapacidadeKWh { get; set; }
        public int SaudeBateria { get; set; }
    }
}