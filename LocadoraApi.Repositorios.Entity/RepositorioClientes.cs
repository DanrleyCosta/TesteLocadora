using LocadoraApi.Comum.Repositorios.Entity;
using LocadoraWebApi.Consumo.Entity.Context;
using LocadoraWebApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraApi.Repositorios.Entity
{
    public class RepositorioClientes : RepositorioLocadoraApi<Cliente, int>
    {
        // Repassando DbContext
        public RepositorioClientes(LocadoraDb context)
            : base(context)
        {

        }
    }
}
