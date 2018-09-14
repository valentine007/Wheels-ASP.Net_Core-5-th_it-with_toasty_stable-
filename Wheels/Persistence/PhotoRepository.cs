using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wheels.Core;
using Wheels.Core.Models;

namespace Wheels.Persistence
{
	public class PhotoRepository : IPhotoRepository
	{
		private readonly WheelsDbContext context;
		public PhotoRepository(WheelsDbContext context)
		{
			this.context = context;
		}
		public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
		{
			return await context.Photos
			  .Where(p => p.VehicleId == vehicleId)
			  .ToListAsync();
		}
	}
}
