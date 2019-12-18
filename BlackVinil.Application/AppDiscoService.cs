using System.Collections.Generic;
using BlackVinil.Domain.Entities;
using BlackVinil.Application.Interfaces;
using BlackVinil.Domain.Interfaces.Service;


namespace BlackVinil.Application
{
    public class AppDiscoService : AppServiceBase<Disco>, IAppDiscoService
    {
        private readonly IDiscoService _service;

        public AppDiscoService(IDiscoService service)
            : base(service)
        {
            _service = service;
        }

        public IEnumerable<Disco> GetAll(GeneroMusical genero)
        {
            return _service.GetAll(genero);
        }

        public Disco GetById(string id)
        {
            return _service.GetById(id);
        }
      
    }
}
