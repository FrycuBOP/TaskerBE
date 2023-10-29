using Microsoft.EntityFrameworkCore;
using System.Threading;
using Tasker.TruckManager.Domain.Entities;
using Tasker.TruckManager.Domain.Persistance;
using Tasker.TruckManager.Infrastructure.Interfaces.Repositories;

namespace Tasker.TruckManager.Application.Repositories.TruckRepositories
{
    public sealed class TruckRepository : ITruckRepository
    {
        private readonly TruckDbContext _context;

        public TruckRepository(TruckDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddTruck(Truck truck,CancellationToken cancellationToken)
        {
            var truckEntry =_context.Trucks.Add(truck);
            await _context.SaveChangesAsync(cancellationToken);
            return truckEntry.Entity.Id;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var truck = await GetById(id, cancellationToken);

            if(truck != null)
            {
                _context.Trucks.Remove(truck);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Truck?> GetById(Guid id, CancellationToken cancellationToken)
            => await _context.Trucks.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);

        public async Task Update(Truck truck, CancellationToken cancellationToken)
        {
            _context.Trucks.Update(truck);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
