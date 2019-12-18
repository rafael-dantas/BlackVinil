using BlackVinil.Domain.Entities;
using BlackVinil.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace BlackVinil.Domain.Interfaces.Repository
{
    public interface IDiscoRepository : IRepositoryBase<Disco>
    {       
        IEnumerable<Disco> GetAll(GeneroMusical genero);
        Disco GetById(string id);
    }
}
