﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasker.TruckManager.Domain.Enums;

namespace Tasker.TruckManager.Domain.Entities
{
    public class Truck
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public StatusEnum Status { get; private set; } = StatusEnum.Returned;
        public string Description { get; set; }


        public void SetOutOfService()
        {
            Status = StatusEnum.OutOfService;
        }

        public bool SetLoading()
        {
            if (Status == StatusEnum.OutOfService ||
                 Status == StatusEnum.Returned ||
                 Status == StatusEnum.Loading)
            {
                Status = StatusEnum.Loading;
                return true;
            }
            return false;
        }

        public bool SetToJob()
        {
            if (Status == StatusEnum.OutOfService || Status == StatusEnum.Loading)
            {
                Status = StatusEnum.ToJob;
                return true;
            }
            return false;
        }
        public bool SetAtJob()
        {
            if (Status == StatusEnum.OutOfService || Status == StatusEnum.ToJob)
            {
                Status = StatusEnum.AtJob;
                return true;
            }
            return false;
        }
        public bool SetReturning()
        {
            if(Status == StatusEnum.OutOfService ||Status == StatusEnum.AtJob)
            {
                Status = StatusEnum.Returning;
                return true;
            }
            return false;
        }
        public bool SetReturned()
        {
            if(Status == StatusEnum.OutOfService || Status == StatusEnum.Returning)
            {
                Status = StatusEnum.Returned;
                return true;
            }
            return false;
        }
    }
}
