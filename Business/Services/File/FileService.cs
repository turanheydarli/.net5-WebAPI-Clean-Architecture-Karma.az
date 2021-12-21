using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.File
{
	public class FileService : IFileService
	{


		public async Task<Entities.Concrete.Image> SaveImage(IFormFile file, string folder)
		{
			string fileName = Guid.NewGuid().ToString() + "-original.jpeg";
			string fullPath = Path.Combine(folder, fileName);

			using var image = file.OpenReadStream();

			var myImage = SixLabors.ImageSharp.Image.Load(image);

			await myImage.SaveAsJpegAsync(fullPath);

			return new Entities.Concrete.Image
			{
				Original = fileName,
				Thumbnail = await SaveThumbnail(myImage, folder, 300, 300),
				CreatedAt = DateTime.Now
			};
		}

		public static async Task<string> SaveThumbnail(SixLabors.ImageSharp.Image image, string folder, int width, int height)
		{



			bool isHeight = image.Height > image.Width;

			if (isHeight)
				image.Mutate(x => x.Crop(image.Width, image.Width));

			if (!isHeight)
				image.Mutate(x => x.Crop(image.Height, image.Height));


			string fileName = Guid.NewGuid().ToString() + "-thumbnail.jpeg";
			await image.SaveAsJpegAsync(Path.Combine(folder, fileName));

			return fileName;

		}

		public async Task<Entities.Concrete.Image> UpdateImage(Entities.Concrete.Image imageToUpdate, IFormFile file, string folder)
		{
			if (imageToUpdate != null)
			{
				string fullPath = Path.Combine(folder, imageToUpdate.Original);
				string fullThumbnailPath = Path.Combine(folder, imageToUpdate.Thumbnail);
				DeleteImage(fullPath);
				DeleteImage(fullThumbnailPath);
			}
			
			return await SaveImage(file, folder);
		}

		private static void DeleteImage(string fullPath)
		{
			if (System.IO.File.Exists(fullPath))
			{
				System.IO.File.Delete(fullPath);
			}
		}
	}

}


