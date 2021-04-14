using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkullJocks.BenAdmin.Application.Contracts.Infastructure;
using SkullJocks.BenAdmin.Application.Models.Mail;
using SkullJocks.BenAdmin.Infastructure.Mail;

namespace SkullJocks.BenAdmin.Infastructure
{
    public static class InfastructureServiceRegistration
    {
        public static IServiceCollection AddInfastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
