﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.TruckManager.Domain.Enums
{
    public enum StatusEnum
    {
        OutOfService,
        Loading,
        ToJob,
        AtJob,
        Returning,
        Returned,
    }
}
