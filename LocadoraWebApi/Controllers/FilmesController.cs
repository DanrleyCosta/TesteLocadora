﻿using LocadoraApi.Comum.Repositorios.Interfaces;
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

        public IHttpActionResult Get()
        {
            return Ok(_repositorioFilmes.Selecionar());
        }
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            Filme filme = _repositorioFilmes.SelecionarPorId(id.Value);

            if (filme == null)
                return NotFound();

            return Content(HttpStatusCode.Found,filme);
        }
        public IHttpActionResult Post([FromBody] Filme filme)
        {
            // tratamento caso não seja criado corretamente o filme
            try
            {
                _repositorioFilmes.Inserir(filme);
                return Created($"{Request.RequestUri}/{filme.Id}", filme);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int? id, [FromBody] Filme filme)
        {
            // tratamento caso não seja criado corretamente o filme
            try
            {
                // modificação do status do filme
                if (!id.HasValue)
                    return BadRequest();


                filme.Id = id.Value;
                _repositorioFilmes.Atualizar(filme);
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
                _repositorioFilmes.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
