using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWcfService.ModelCliente
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
