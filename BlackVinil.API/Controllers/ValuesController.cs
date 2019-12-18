using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackVinil.Application;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Service;
using BlackVinil.Infra.Data.Repository;
using BlackVinil.IoC;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace BlackVinil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAppDiscoService _appDisco;

        
        public ValuesController(IAppDiscoService appDisco)
        {
            _appDisco = appDisco;// ModuleInject.Load(appDisco);// new AppDiscoService(new DiscoService(new DiscoRepository()));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           

            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {            
            Disco discos = _appDisco.GetById(id);
            return Ok(discos);// new string[] { "value1", "value2" };
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
