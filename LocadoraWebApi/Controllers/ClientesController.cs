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
    public class ClientesController : ApiController
    {
        private IRepositorioLocadoraApi<Cliente, int> _repositorioClientes = new RepositorioClientes(new LocadoraDb());

        public IHttpActionResult Get()
        {
            return Ok(_repositorioClientes.Selecionar());
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            
            Cliente cliente = _repositorioClientes.SelecionarPorId(id.Value);

            if(cliente == null)            
                return NotFound();

            return Content(HttpStatusCode.Found, cliente);
        }
        public IHttpActionResult Post([FromBody] Cliente cliente)
        {
            // tratamento caso não seja criado corretamente o cliente
            try
            {
                _repositorioClientes.Inserir(cliente);
                return Created($"{Request.RequestUri}/{cliente.Id}", cliente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int? id, [FromBody] Cliente cliente)
        {
            // tratamento caso não seja criado corretamente o cliente
            try
            {
                // modificação do status do cliente
                if (!id.HasValue)
                    return BadRequest();
                cliente.Id = id.Value;
                _repositorioClientes.Atualizar(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int? id)
        {
            // tratamento caso não seja criado corretamente o cliente
            try
            {
                // modificação do status do cliente
                if (!id.HasValue)
                    return BadRequest();
                _repositorioClientes.ExcluirPorId(id.Value);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
