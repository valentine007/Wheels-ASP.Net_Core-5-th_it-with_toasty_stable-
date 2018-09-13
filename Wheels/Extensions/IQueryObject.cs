using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheels.Extensions
{
    public interface IQueryObject
    {
		string SortBy { get; set; }
		bool IsSortByAscending { get; set; }
	}
}
