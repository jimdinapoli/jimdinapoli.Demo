using System;
using System.Collections.Generic;
using System.Text;

namespace SkullJocks.BenAdmin.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) not found.")
        {                
        }
    }
}
