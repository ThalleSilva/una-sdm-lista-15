using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenDriveApi324119278.Model
{
    public class OrdemReciclagem
    {
        public int Id { get; set; }
        public int BateriaId { get; set; }
        public int EstacaoId { get; set; }
        public string Prioridade { get; set; }
        public decimal CustoProcessamento { get; set; }

        public Bateria? Bateria { get; set; }
        public EstacaoCarga? EstacaoCarga { get; set; }
    }
}