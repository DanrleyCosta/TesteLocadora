using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraWebApi.Dominio
{
    // Notas do Teste: Criei propriedades bem simples para facilitar o desenvolvimento
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
