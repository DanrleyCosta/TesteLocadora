using LocadoraApi.Comum.Repositorios.Interfaces;
using LocadoraApi.Repositorios.Entity;
using LocadoraWebApi.Consumo.Entity.Context;
using LocadoraWebApi.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LocadoraWebApi.Controllers
{
    public class LocacoesController : ApiController
    {
        private IRepositorioLocadoraApi<Locacao, int> _repositorioLocacoes = new RepositorioLocacoes(new LocadoraDb());

        public IEnumerable<Locacao> Get()
        {
            return _repositorioLocacoes.Selecionar();
        }
        public HttpResponseMessage Get(int? id)
        {
            if (!id.HasValue)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Locacao locacao = _repositorioLocacoes.SelecionarPorId(id.Value);

            if (locacao == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.Found, locacao);
        }
        public HttpResponseMessage Post([FromBody] Locacao locacao)
        {
            // tratamento caso não seja criado corretamente a locaçao
            try
            {
                _repositorioLocacoes.Inserir(locacao);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public HttpResponseMessage Put(int? id, [FromBody] Locacao locacao)
        {
            // tratamento caso não seja criado corretamente a locaçao
            try
            {
                // modificação do status da locação
                if (!id.HasValue)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                locacao.Id = id.Value;
                _repositorioLocacoes.Atualizar(locacao);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
