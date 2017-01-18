using EnclosuresFinder.Data.Abstract;
using EnclosuresFinder.Model.Entities;
using System.Collections;

namespace EnclosuresFinder.Data.Repositories
{
    public class EnclosureRepository : EntityBaseRepository<Enclosure>, IEnclosureRepository
    {
        public EnclosureRepository(EnclosureContext context)
            : base(context)
        { }
        
    }

}
