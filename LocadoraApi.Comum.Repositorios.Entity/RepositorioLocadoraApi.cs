using LocadoraApi.Comum.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraApi.Comum.Repositorios.Entity
{
    // manipulação de todos os dominios, para que funcionem em todas as entidades, como e uma classe base coloquei abstract para que não haja instanciação
    public abstract class RepositorioLocadoraApi<TDominio, TChave> : IRepositorioLocadoraApi<TDominio, TChave>
        where TDominio : class
    {
        protected DbContext _context;

        public RepositorioLocadoraApi(DbContext context)
        {
            _context = context;
        }
        public void Atualizar(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Modified; // gerar updates
            _context.SaveChanges();
        }

        public void Inserir(TDominio dominio)
        {
            _context.Set<TDominio>().Add(dominio);
            _context.SaveChanges();
        }

        public List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null)
        {
            DbSet<TDominio> dbset = _context.Set<TDominio>();
            if (where == null)
                return dbset.ToList();
            else
                return dbset.Where(where).ToList();
        }

        public TDominio SelecionarPorId(TChave id)
        {
            return _context.Set<TDominio>().Find(id);
        }
    }
}
