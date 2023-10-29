using Microsoft.EntityFrameworkCore;
using Tasker.TruckManager.Domain.Entities;

namespace Tasker.TruckManager.Domain.Persistance
{
    public class TruckDbContext : DbContext
    {
        public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Truck> Trucks { get; set; }
    }
}
