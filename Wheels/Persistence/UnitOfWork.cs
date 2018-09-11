using System.Threading.Tasks;
using Wheels.Core;

namespace Wheels.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly WheelsDbContext context;

		public UnitOfWork(WheelsDbContext context)
		{
			this.context = context;
		}

		public async Task CompleteAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}