using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;

namespace SkullJocks.BenAdmin.Application.Contracts.Persistence
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
    }
}
