using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediaum.Domain.Exceptions
{
    public class SomethingWentWrongException : Exception
    {
        public SomethingWentWrongException(string message)
        : base(message)
        { }
    }
}
