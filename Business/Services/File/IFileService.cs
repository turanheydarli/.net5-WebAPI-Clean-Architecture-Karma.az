using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.File
{
	public interface IFileService
	{
		Task<Image> SaveImage(IFormFile file, string folder);
		Task<Image> UpdateImage(Image imageToUpdate, IFormFile file, string folder);
	}
}
