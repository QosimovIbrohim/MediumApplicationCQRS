using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediaum.Domain.Exceptions
{
    public class _404NotFoundException : Exception
    {
        public _404NotFoundException(string message)
        : base(message)
        { }

    }
}
