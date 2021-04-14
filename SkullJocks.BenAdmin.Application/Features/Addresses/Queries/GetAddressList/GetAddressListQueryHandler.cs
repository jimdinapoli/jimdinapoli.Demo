using AutoMapper;
using MediatR;
using SkullJocks.BenAdmin.Domain.Entities.ContactDetails;
using SkullJocks.BenAdmin.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.Application.Features.Addresses.Queries
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, AddressListModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Address> _addressRepository;
        private readonly IAsyncRepository<Contact> _contactRepository;

        public GetAddressListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Address> addressRepository,
            IAsyncRepository<Contact> contactRepository
            )
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public async Task<AddressListModel> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
