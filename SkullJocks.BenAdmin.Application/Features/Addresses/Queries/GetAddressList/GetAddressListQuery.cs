using MediatR;
using System;

namespace SkullJocks.BenAdmin.Application.Features.Addresses.Queries
{
    public class GetAddressListQuery : IRequest<AddressListModel>
    {
        public Guid Id { get; set; }
    }
}
