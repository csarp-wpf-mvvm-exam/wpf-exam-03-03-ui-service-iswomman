using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class TeacherRepo<TDbConstext> : RepositoryBase<TDbConstext, Teacher>, ITeacherRepo
        where TDbConstext : DbContext
    {
        public TeacherRepo(IDbContextFactory<TDbConstext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
