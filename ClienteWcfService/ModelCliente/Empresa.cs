using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteWcfService.ModelCliente
{
    public class Empresa
    {
        //public int _Id;
        //public string _Nome;
        //public string _Cnpj;
        //public List<Funcionario> _Funcionarios;

        //public Empresa(int _Id, string _Nome, string _Cnpj, List<Funcionario> _Funcionarios)
        //{
        //    this.Id = _Id;
        //    this.Nome = _Nome;
        //    this.cnpj = _Cnpj;
        //    this.Funcionarios = _Funcionarios;

        //}

        public int Id { get; set; }
        public string Nome { get; set; }
        public string cnpj { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

    }
}