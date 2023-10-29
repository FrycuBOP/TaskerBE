using Tasker.Shared.Exceptions.CommonExceptions;
using Tasker.TruckManager.Application.Interfaces.Repositories;
using Tasker.TruckManager.Application.Interfaces.Services;
using Tasker.TruckManager.Domain.Entities;
using Tasker.TruckManager.Domain.Enums;
using Tasker.TruckManager.Infrastructure.Exceptions;

namespace Tasker.TruckManager.Infrastructure.Services.TruckServices
{
    public sealed class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<Guid> AddTruck(Truck truck, CancellationToken cancellationToken) => await _truckRepository.AddTruck(truck, cancellationToken);
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _truckRepository.Delete(id, cancellationToken);
        }

        public async Task<Truck> GetById(Guid id, CancellationToken cancellationToken)
        {
            var truck = await _truckRepository.GetById(id, cancellationToken);
            if (truck != null)
            {
                return truck;
            }

            throw new NotFoundException($"Truck with id: {id} not found");
        }

        public async Task Update(Truck truck, CancellationToken cancellationToken)
        {
            var truckDb = await GetById(truck.Id, cancellationToken);

            if (!SetStatus(truckDb, truck.Status))
            {
                throw new StatusCannotBeChangeException(truckDb.Status, truck.Status);
            }

            truckDb.Description = truck.Description;
            truckDb.Name = truck.Name;

            await _truckRepository.Update(truckDb, cancellationToken);
        }

        private static bool SetStatus(Truck truck, StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.OutOfService:
                    truck.SetOutOfService();
                    return true;
                case StatusEnum.Loading:
                    return truck.SetLoading();
                case StatusEnum.ToJob:
                    return truck.SetToJob();
                case StatusEnum.AtJob:
                    return truck.SetAtJob();
                case StatusEnum.Returning:
                    return truck.SetReturning();
                case StatusEnum.Returned:
                    return truck.SetReturned();
            }

            return false;

        }

    }
}
