using Kreata.Backend.Context;
using Kreata.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.ContextRepos
{
    public class TeacherInMemoryRepo : TeacherRepo<KretaInMemoryContext>, ITeacherRepo
    {
        public TeacherInMemoryRepo(IDbContextFactory<KretaInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
