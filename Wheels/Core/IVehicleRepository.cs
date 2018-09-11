using System.Threading.Tasks;
using Wheels.Core.Models;

namespace Wheels.Core
{
	public interface IVehicleRepository
	{
		Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
		void Add(Vehicle vehicle);
		void Remove(Vehicle vehicle);
	}
}
