using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotInvest
{
    public class Investiment
    {
        public int Quantidade { get; set; }
        public decimal PrecoCompra { get; set; }
        public string PrecoMercado { get; set; }
        public decimal PrecoMinDia { get; set; }
        public decimal PrecoMaxDia { get; set; }
    }
}
