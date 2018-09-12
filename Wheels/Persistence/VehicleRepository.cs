using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheels.Models;

namespace Wheels.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
		private readonly WheelsDbContext context;

		public VehicleRepository(WheelsDbContext context)
		{
			this.context = context;
		}

		public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
		{
			if (!includeRelated)
				return await context.Vehicles.FindAsync(id);

			return await context.Vehicles
				.Include(v => v.Features)
				.ThenInclude(vf => vf.Feature)
				.Include(v => v.Model)
				.ThenInclude(m => m.Make)
				.SingleOrDefaultAsync(v => v.Id == id);
		}

		public async Task<Vehicle> GetVehicleWithMake(int id, bool includeRelated = true)
		{
			if (includeRelated != false)
				return await context.Vehicles.FindAsync(id);

			return await context.Vehicles
			  .Include(v => v.Features)
				.ThenInclude(vf => vf.Feature)
			  .Include(v => v.Model)
				.ThenInclude(m => m.Make)
			  .SingleOrDefaultAsync(v => v.Id == id);
		}

		public void Add(Vehicle vehicle)
		{
			context.Vehicles.Add(vehicle);
		}

		public void Remove(Vehicle vehicle)
		{
			context.Remove(vehicle);
		}
    }
}
