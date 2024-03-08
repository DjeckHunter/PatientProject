using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatientProject.Core.Interfaces.Generic;
using PatientProject.Infrastructure.Repository;

namespace PatientProject.Infrastructure
{
    public static class StartupInfrastructure
    {
        public static void AddRepositoryContext(this IServiceCollection services, string connectionString) => 
            services.AddDbContext<RepositoryContext>(opt => opt.UseNpgsql(connectionString));

        public static void AddRepositoryInfrastructure(this IServiceCollection services) => 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
