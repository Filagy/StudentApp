using System;
using System.Collections.Generic;
using System.Text;

namespace StudentASP.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity\"{name}\" {key} not found.") { }
    }
}
