﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheels.Core.Models;
using Wheels.Models;

namespace Wheels.Persistence
{
    public interface IVehicleRepository
    {
		Task<Vehicle> GetVehicle(int id, bool includeRelated = true);

		void Add(Vehicle vehicle);

		void Remove(Vehicle vehicle);

		Task<IEnumerable<Vehicle>> GetVehicles(VehicleQuery filter);
	}
}
