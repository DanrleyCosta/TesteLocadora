using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNlavaJato.Entidades
{
    public class LavaJatoData
    {
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public string TipoServico { get; set; }
        public decimal ValorServico { get; set; }
        public string FuncionarioResponsavel { get; set; }
        public string PlacaVeiculo { get; set; }
        public string Observacoes { get; set; }
    }
}
