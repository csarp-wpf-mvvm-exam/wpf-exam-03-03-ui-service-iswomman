using Kreata.Backend.Context;
using Kreata.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.ContextRepos
{
    public class ParentInMemoryRepo : ParentRepo<KretaInMemoryContext>, IParentRepo
    {
        public ParentInMemoryRepo(IDbContextFactory<KretaInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
