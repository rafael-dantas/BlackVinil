using BlackVinil.Domain.Entities;
using System.Collections.Generic;

namespace BlackVinil.Application.Interfaces
{
    public interface IAppDiscoService : IAppServiceBase<Disco>
    {        
        IEnumerable<Disco> GetAll(GeneroMusical genero);

        Disco GetById(string id);
    }
}
