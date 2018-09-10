using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheels.Controllers.Resources;
using Wheels.Models;
using Wheels.Persistence;

namespace Wheels.Controllers
{
    public class MakesController : Controller
    {
		private readonly WheelsDbContext context;
		private readonly IMapper mapper;

		public MakesController(WheelsDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		[HttpGet("/api/makes")]
		public async Task<IEnumerable<MakeResource>> GetMakes()
		{
			var makes = await context.Makes.Include(m => m.Models).ToListAsync();

			return mapper.Map<List<Make>, List<MakeResource>>(makes);
		}
    }
}
