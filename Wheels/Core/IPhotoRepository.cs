using System.Collections.Generic;
using System.Threading.Tasks;
using Wheels.Core.Models;

namespace Wheels.Core
{
	public interface IPhotoRepository
	{
		Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
	}
}