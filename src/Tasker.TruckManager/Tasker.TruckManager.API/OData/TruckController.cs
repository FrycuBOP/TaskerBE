using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Tasker.TruckManager.Domain.Entities;
using Tasker.TruckManager.Domain.Persistance;

namespace Tasker.TruckManager.API.OData
{
    public class TrucksController : ODataController
    {
        private readonly TruckDbContext _context;
        public TrucksController(TruckDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Truck> Get()
        {
            return _context.Trucks.AsQueryable();
        }
    }
}
