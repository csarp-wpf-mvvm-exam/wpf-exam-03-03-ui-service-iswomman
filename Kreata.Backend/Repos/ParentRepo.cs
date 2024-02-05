using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class ParentRepo<TDbConstext> : RepositoryBase<TDbConstext, Parent>, IParentRepo
        where TDbConstext : DbContext
    {
        public ParentRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
