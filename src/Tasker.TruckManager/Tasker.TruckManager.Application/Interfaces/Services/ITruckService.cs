using Tasker.TruckManager.Domain.Entities;

namespace Tasker.TruckManager.Application.Interfaces.Services
{
    public interface ITruckService : IService
    {
        Task<Guid> AddTruck(Truck truck, CancellationToken cancellationToken);
        Task<Truck> GetById(Guid id, CancellationToken cancellationToken);
        Task Update(Truck truck, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
