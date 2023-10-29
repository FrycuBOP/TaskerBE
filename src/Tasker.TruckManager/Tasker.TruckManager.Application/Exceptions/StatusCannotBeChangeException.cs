using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tasker.Shared.Exceptions;
using Tasker.TruckManager.Domain.Enums;

namespace Tasker.TruckManager.Application.Exceptions
{
    internal class StatusCannotBeChangeException : TaskerBaseException
    {
        public StatusCannotBeChangeException(StatusEnum newStatus,StatusEnum oldStatus)
        {
             ExceptionMessage = $"Cannot change status {oldStatus} to {newStatus}";
        }
        public override string ExceptionMessage { get; }

        public override int StatusCode => 400;
    }
}
