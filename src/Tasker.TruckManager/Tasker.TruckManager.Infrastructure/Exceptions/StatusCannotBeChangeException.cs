﻿using Tasker.Shared.Exceptions;
using Tasker.TruckManager.Domain.Enums;

namespace Tasker.TruckManager.Infrastructure.Exceptions
{
    internal class StatusCannotBeChangeException : TaskerBaseException
    {
        public StatusCannotBeChangeException(StatusEnum newStatus, StatusEnum oldStatus)
        {
            ExceptionMessage = $"Cannot change status {oldStatus} to {newStatus}";
        }
        public override string ExceptionMessage { get; }

        public override int StatusCode => 400;
    }
}
