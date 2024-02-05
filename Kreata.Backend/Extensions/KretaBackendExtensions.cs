using Kreata.Backend.Context;
using Kreata.Backend.ContextRepos;
using Kreata.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Extensions
{
    public static class KretaBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "Kreta" + Guid.NewGuid();
            services.AddDbContextFactory<KretaContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
            services.AddDbContextFactory<KretaInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
        }

        public static void ConfigureRepos(this IServiceCollection services) 
        { 
            services.AddScoped<IStudentRepo, StudentInMemoryRepo>();
            services.AddScoped<ITeacherRepo, TeacherInMemoryRepo>();
            services.AddScoped<IParentRepo, ParentInMemoryRepo>();
        }
    }
}
