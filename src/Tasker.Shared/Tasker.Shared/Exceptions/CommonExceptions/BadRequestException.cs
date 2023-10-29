using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Shared.Exceptions.CommonExceptions
{
    public class BadRequestException : TaskerBaseException
    {
        public BadRequestException(string errorMsg)
        {
            ExceptionMessage = errorMsg;
        }
        public override string ExceptionMessage { get; }

        public override int StatusCode => 400;
    }
}
