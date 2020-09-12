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
    // Class que implementa todos os verbos que indentificam o RESTful
    public class LocacoesController : ApiController
    {
        private IRepositorioLocadoraApi<Locacao, int> _repositorioLocacoes = new RepositorioLocacoes(new LocadoraDb());

        public IHttpActionResult Get()
        {
            return Ok(_repositorioLocacoes.Selecionar());
        }
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            Locacao locacao = _repositorioLocacoes.SelecionarPorId(id.Value);

            if (locacao == null)
                return NotFound();

            return Content(HttpStatusCode.Found, locacao);
        }
        public IHttpActionResult Post([FromBody] Locacao locacao)
        {
            // tratamento caso não seja criado corretamente a locaçao
            try
            {
                _repositorioLocacoes.Inserir(locacao);
                return Created($"{Request.RequestUri}/{locacao.Id}", locacao);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int? id, [FromBody] Locacao locacao)
        {
            // tratamento caso não seja criado corretamente a locaçao
            try
            {
                // modificação do status da locação
                if (!id.HasValue)
                    return BadRequest();

                locacao.Id = id.Value;
                _repositorioLocacoes.Atualizar(locacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int? id)
        {
            // tratamento caso não seja criado corretamente o filme
            try
            {
                // Excluir por ID
                if (!id.HasValue)
                    return BadRequest();
                _repositorioLocacoes.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
