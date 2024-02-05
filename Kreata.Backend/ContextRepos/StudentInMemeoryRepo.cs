using Kreata.Backend.Context;
using Kreata.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.ContextRepos
{
    public class StudentInMemoryRepo : StudentRepo<KretaInMemoryContext>, IStudentRepo
    {
        public StudentInMemoryRepo(IDbContextFactory<KretaInMemoryContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
