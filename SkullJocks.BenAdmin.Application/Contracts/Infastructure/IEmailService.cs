using SkullJocks.BenAdmin.Application.Models.Mail;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Contracts.Infastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
