using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheels.Extensions;

namespace Wheels.Core.Models
{
    public class VehicleQuery : IQueryObject
    {
		public int? MakeId { get; set; }
		public int? ModelId { get; set; }
		public string SortBy { get; set; }
		public bool IsSortByAscending { get; set; }
		public int Page { get; set; }
		public byte PageSize { get; set; }
	}
}
