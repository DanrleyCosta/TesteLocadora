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
    public class RepositorioFilmes : RepositorioLocadoraApi<Filme,int>
    {
        // Repassando DbContext
        public RepositorioFilmes(LocadoraDb context)
            : base(context)
        {

        }
    }
}
