using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Dominio
{
    public class Locacao
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int Estoque { get; set; }
        public List<Filme> Filmes { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
