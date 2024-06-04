using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyBackend.services
{
    public class OperationNotAllowedException : Exception
    {
        public OperationNotAllowedException(string message) : base(message)
        {
        }

        public OperationNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
