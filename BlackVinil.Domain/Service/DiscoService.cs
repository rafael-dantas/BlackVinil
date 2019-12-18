using System.Collections.Generic;
using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Repository;
using BlackVinil.Domain.Interfaces.Service;

namespace BlackVinil.Domain.Service
{
    public class DiscoService : ServiceBase<Disco>, IDiscoService
    {
        private readonly IDiscoRepository _repository;

        public DiscoService(IDiscoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Disco> GetAll(GeneroMusical genero)
        {
            return _repository.GetAll(genero);
        }

        public Disco GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}
