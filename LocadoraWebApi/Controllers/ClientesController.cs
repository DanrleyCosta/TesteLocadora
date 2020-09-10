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

        public IEnumerable<Cliente> Get()
        {
            return _repositorioClientes.Selecionar();
        }

        public HttpResponseMessage Get(int? id)
        {
            if (!id.HasValue)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            
            Cliente cliente = _repositorioClientes.SelecionarPorId(id.Value);

            if(cliente == null)            
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.Found,cliente);
        }
        public HttpResponseMessage Post([FromBody] Cliente cliente)
        {
            // tratamento caso não seja criado corretamente o cliente
            try
            {
                _repositorioClientes.Inserir(cliente);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
