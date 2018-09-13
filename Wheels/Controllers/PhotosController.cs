using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wheels.Controllers.Resources;
using Wheels.Core.Models;
using Wheels.Persistence;

namespace Wheels.Controllers
{
	[Route("/api/vehicles/{vehicleId}/photos")]
	public class PhotosController : Controller
	{
		private readonly IHostingEnvironment host;
		private readonly IVehicleRepository repository;
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;
		public PhotosController(IHostingEnvironment host, IVehicleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.mapper = mapper;
			this.unitOfWork = unitOfWork;
			this.repository = repository;
			this.host = host;
		}
		[HttpPost]
		public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
		{
			var vehicle = await repository.GetVehicle(vehicleId, includeRelated: false);
			if (vehicle == null)
				return NotFound();
			var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
			if (!Directory.Exists(uploadsFolderPath))
				Directory.CreateDirectory(uploadsFolderPath);
			var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			var filePath = Path.Combine(uploadsFolderPath, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			var photo = new Photo { FileName = fileName };
			vehicle.Photos.Add(photo);
			await unitOfWork.CompleteAsync();
			return Ok(mapper.Map<Photo, PhotoResource>(photo));
		}
	}
} 