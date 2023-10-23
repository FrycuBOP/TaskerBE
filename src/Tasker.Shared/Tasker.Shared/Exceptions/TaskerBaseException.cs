using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Shared.Exceptions
{
    public abstract class TaskerBaseException : Exception
    {
        protected TaskerBaseException() : base() { }

        protected TaskerBaseException(string message) : base(message)
        {
        }

        protected TaskerBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        protected TaskerBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public abstract string ExceptionMessage { get; }
        public abstract int StatusCode { get; }
    }
}
