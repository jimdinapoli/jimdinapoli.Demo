using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkullJocks.BenAdmin.Persistence.Repositories;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;

namespace SkullJocks.BenAdmin.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BenAdminContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();

            return services;
        }
    }
}
