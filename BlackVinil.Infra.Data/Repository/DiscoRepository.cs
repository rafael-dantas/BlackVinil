using System.Linq;
using System.Collections.Generic;
using BlackVinil.Domain.Entities;
using BlackVinil.Infra.Data.API_Spotfy;
using BlackVinil.Domain.Interfaces.Repository;


namespace BlackVinil.Infra.Data.Repository
{
    public class DiscoRepository : RepositoryBase<Disco>, IDiscoRepository
    {    
        public IEnumerable<Disco> GetAll(GeneroMusical genero)
        {            
            List<Disco> discos = new ApiSpotfy().GetDiscos(genero).ToList();
            List<Disco> discosDB = Db.Set<Disco>().Where(g => g.Genero == genero).ToList();
            List<Disco> discosNOVOS = new List<Disco>();
            int cont = 0;
            foreach (Disco d in discos)
            {
                discos[cont].Preco = CashBack.Preco(genero);
                discos[cont].CashBack = CashBack.Calcular(genero);
                if (!discosDB.Exists(x => x.Id == d.Id))
                     discosNOVOS.Add(d);
                cont++;
            }

            if (discosNOVOS.Count() > 0)
            {
                Db.Set<Disco>().AddRange(discosNOVOS);
                Db.SaveChanges();
            }
           
            return discos.Count() > 0 ? discos : null;
        }      

        public Disco GetById(string id)
        {
           return Db.Set<Disco>().Find(id);
        }
    }
}
