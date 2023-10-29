using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Shared.Exceptions.CommonExceptions
{
    public class NotFoundException : TaskerBaseException
    {
        public NotFoundException(string msg)
        {
            ExceptionMessage = msg;   
        }
        public override string ExceptionMessage { get; }

        public override int StatusCode => 404;
    }
}
