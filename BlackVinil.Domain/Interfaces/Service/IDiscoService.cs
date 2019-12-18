using BlackVinil.Domain.Entities;
using System.Collections.Generic;

namespace BlackVinil.Domain.Interfaces.Service
{
    public interface IDiscoService : IServiceBase<Disco>
    {       
        IEnumerable<Disco> GetAll(GeneroMusical genero);
        Disco GetById(string id);
    }
}
