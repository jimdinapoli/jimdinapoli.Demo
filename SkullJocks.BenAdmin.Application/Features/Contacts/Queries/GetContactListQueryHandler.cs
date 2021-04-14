using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Contacts
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Contact> _contactRepository;

        public GetContactListQueryHandler(IMapper mapper, IAsyncRepository<Contact> contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }
        public async Task<List<ContactListViewModel>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var allContacts = (await _contactRepository.ListAllAsync());
            return _mapper.Map<List<ContactListViewModel>>(allContacts);
        }
    }
}
