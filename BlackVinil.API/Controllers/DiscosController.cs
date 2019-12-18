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
    public class DiscosController : ControllerBase
    {
        private readonly IAppDiscoService _discos;

        public DiscosController(IAppDiscoService discos)
        {
            _discos = discos;
        }

        // GET: api/Disco
        [HttpGet]
        [Route("/api/discos/g/{g}")]
        public ActionResult<IEnumerable<Disco>> Get(string g)
        {
            g = string.IsNullOrEmpty(g) ? "" : g.ToUpper();
            GeneroMusical genero = GeneroMusical.POP;
            if (g.Contains("POP"))
                genero = GeneroMusical.POP;
            else if (g.Contains("MPB"))
                genero = GeneroMusical.MPB;
            else if(g.Contains("CLASSIC"))
                genero = GeneroMusical.CLASSIC;
            else if (g.Contains("rock"))
                genero = GeneroMusical.ROCK;
            else
                g = "error";


            IEnumerable<Disco> lista = null;
            if (g != "error")
                lista = _discos.GetAll(genero);

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

        // GET: api/Disco/5
        [HttpGet]
        [Route("/api/discos/{id}")]
        public ActionResult<Disco> Get(string[] id)
        {
            string param = string.Join("", id);
            Disco disco = _discos.GetById(param);
            if (string.IsNullOrEmpty(param))
            {
                return BadRequest(new { Status = "400", Mensagem = "Id não localizado" });
            }
            else if(disco == null)
            {
                return NotFound(new { Status = "404", Mensagem = "Disco não localizado" });
            }
            else
            {
                return Ok(disco);
            }
            
        }

        // POST: api/Disco
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Disco/5
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
