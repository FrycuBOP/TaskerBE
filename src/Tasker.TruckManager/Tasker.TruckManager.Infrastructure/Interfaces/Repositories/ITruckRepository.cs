using Tasker.TruckManager.Domain.Entities;

namespace Tasker.TruckManager.Infrastructure.Interfaces.Repositories
{
    public interface ITruckRepository : IRepository
    {
        Task<Guid> AddTruck(Truck truck,CancellationToken cancellationToken);
        Task<Truck?> GetById(Guid id, CancellationToken cancellationToken);
        Task Update(Truck truck,CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
