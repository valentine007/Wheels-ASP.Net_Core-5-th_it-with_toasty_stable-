using System.Threading.Tasks;

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
			await context.SaveChangesAsync()
;		}
	}
}
