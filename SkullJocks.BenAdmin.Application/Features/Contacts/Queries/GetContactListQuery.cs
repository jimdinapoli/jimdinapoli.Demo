using MediatR;
using System;
using System.Collections.Generic;

namespace SkullJocks.BenAdmin.Application.Features.Contacts
{
    public class GetContactListQuery : IRequest<List<ContactListViewModel>>
    {
        public Guid Id { get; set; }
    }
}
