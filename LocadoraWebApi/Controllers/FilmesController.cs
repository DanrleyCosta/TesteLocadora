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
    public class FilmesController : ApiController
    {
        private IRepositorioLocadoraApi<Filme, int> _repositorioFilmes = new RepositorioFilmes(new LocadoraDb());

        public IEnumerable<Filme> Get()
        {
            return _repositorioFilmes.Selecionar();
        }
        public HttpResponseMessage Get(int? id)
        {
            if (!id.HasValue)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Filme filme = _repositorioFilmes.SelecionarPorId(id.Value);

            if (filme == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.Found, filme);
        }
        public HttpResponseMessage Post([FromBody] Filme filme)
        {
            // tratamento caso não seja criado corretamente o filme
            try
            {
                _repositorioFilmes.Inserir(filme);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
