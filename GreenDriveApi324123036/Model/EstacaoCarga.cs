using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenDriveApi324119278.Model
{
    public class EstacaoCarga
    {
       public int Id { get; set; }
        public string Localizacao { get; set; }
        public string TipoCarga { get; set; }
        public double CargaDisponivelKW { get; set; } 
    }
}