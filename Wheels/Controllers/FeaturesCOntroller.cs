using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wheels.Controllers.Resources;
using Wheels.Models;
using Wheels.Persistence;

namespace vega.Controllers
{
	public class FeaturesController : Controller
	{
		private readonly WheelsDbContext context;
		private readonly IMapper mapper;
		public FeaturesController(WheelsDbContext context, IMapper mapper)
		{
			this.mapper = mapper;
			this.context = context;
		}

		[HttpGet("/api/features")]
		public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
		{
			var features = await context.Features.ToListAsync();

			return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
		}
	}
}