using System;
using System.Threading.Tasks;

namespace Wheels.Core
{
	public interface IUnitOfWork
	{
		Task CompleteAsync();
	}
}