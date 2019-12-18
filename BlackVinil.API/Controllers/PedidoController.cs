using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackVinil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IAppPedidoService _appPedido;
        private readonly IAppDiscoService _appDisco;

        public PedidoController(IAppPedidoService appPedido, IAppDiscoService appDisco)
        {
            _appPedido = appPedido;
            _appDisco = appDisco;
        }

        // GET: api/Pedido
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            IEnumerable<Pedido> lista = _appPedido.GetAll();

            if (lista.Count() > 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound(":(  Você ainda não tem pedidos realizados");
            }

        }

        // GET: api/Pedido
        [HttpGet("/api/pedido/discos/{g}")]
        public ActionResult<IEnumerable<Disco>> Get(string g)
        {
            g = string.IsNullOrEmpty(g) ? "" : g.ToUpper();
            GeneroMusical genero = GeneroMusical.POP;
            if (g.Contains("POP"))
                genero = GeneroMusical.POP;
            else if (g.Contains("MPB"))
                genero = GeneroMusical.MPB;
            else if (g.Contains("CLASSIC"))
                genero = GeneroMusical.CLASSIC;
            else if (g.Contains("rock"))
                genero = GeneroMusical.ROCK;
            else
                g = "error";


            IEnumerable<Disco> lista = null;
            if (g != "error")
                lista = _appDisco.GetAll(genero);

            if (lista == null)
            {
                return BadRequest(new { Status = "400", Mensagem = "Genero Inválido" });
            }
            if (lista.Count() > 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound(new { Status = "404", Mensagem = "Discos não localizados" });
            }

        }

        // GET: api/Pedido/5
        [HttpGet("/api/pedido/{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            Pedido p = _appPedido.GetById(id);
            if (p != null)
            {
                return Ok(p);
            }
            else
            {
                return NotFound(new { Status = "404", Mensagem = "Pedido não localizado" });
            }


        }

        // GET: api/Pedido/5
        [HttpGet("/api/pedido/Pesquisa")]
        public ActionResult<IEnumerable<Pedido>> Get(DateTime dtIni, DateTime dtFim)
        {
            IEnumerable<Pedido> lstPedido = null;

            if ((dtIni > dtFim) || dtIni == DateTime.MinValue || dtFim == DateTime.MinValue || dtIni == null || dtFim == null)
                return BadRequest(new { Status = "400", Mensagem = "Datas Incorretas" });
            else
                lstPedido = _appPedido.GetByDate(dtIni, dtFim);

            if (lstPedido == null)
            {
                return NotFound(new { Status = "404", Mensagem = "Pedido não localizado" });
            }
            else if (lstPedido.Count() > 0)
            {
                return Ok(lstPedido);
            }
            else
            {
                return NotFound(new { Status = "404", Mensagem = "Pedido não localizado" });
            }


        }

        // POST: api/Pedido
        [HttpPost("/api/pedidos/finalizar/{d}")]
        public ActionResult<string> Post(string d)
        {
            try
            {
                _appPedido.Add(d);
                return Ok(new { Status = "200", Mensagem = "Pedido inserido corretamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "400", Mensagem = "Erro nos parametros" });
            }
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
