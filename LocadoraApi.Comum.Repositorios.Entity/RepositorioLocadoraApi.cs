using LocadoraApi.Comum.Repositorios.Interfaces;
using LocadoraWebApi.Consumo.Entity.Context;
using LocadoraWebApi.Dominio;
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
        private LocadoraDb db = new LocadoraDb();

        public RepositorioLocadoraApi(DbContext context)
        {
            _context = context;
        }
        public void Atualizar(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Modified; // gerar updates
            _context.SaveChanges();
        }

        public void DevolverPorId(TChave id, DateTime dataDevolucao)
        {
            TDominio dominio = SelecionarPorId(id);
            Locacao locacao = db.Locacoes.Find(id);
            locacao.DataDevolucao = dataDevolucao;
            Atualizar(dominio);
        }

        public void Excluir(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            TDominio dominio = SelecionarPorId(id);
            Excluir(dominio);
        }

        public void Inserir(TDominio dominio)
        {
            _context.Set<TDominio>().Add(dominio);
            _context.SaveChanges();
        }

        public void LocarPorId(Locacao locacao)
        {
            locacao.Filme = db.Filmes.Find(locacao.FId);
            locacao.Cliente = db.Clientes.Find(locacao.CId);
            if (!locacao.PossuiCreditos())
                throw new Exception("Cliente não possui créditos suficientes para locação");
            _context.Set<Locacao>().Add(locacao);
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
