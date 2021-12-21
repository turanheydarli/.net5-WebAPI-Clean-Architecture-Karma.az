using Business.Services.File;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Images.Commands
{
	public class UpdateImageCommand : IRequest<Image>
	{
		public int ImageId { get; set; }
		public IFormFile File { get; set; }

		public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, Image>
		{
			public IImageDal _imageDal { get; set; }
			private readonly IFileService _fileService;
			IHostEnvironment _env;
			public UpdateImageCommandHandler(IImageDal imageDal, IFileService fileService, IHostEnvironment env)
			{
				_imageDal = imageDal;
				_fileService = fileService;
				_env = env;
			}

			public async Task<Image> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
			{
				var imageToUpdate = await _imageDal.GetAsync(i => i.Id == request.ImageId);

				return await _fileService.UpdateImage(imageToUpdate, request.File, Path.Combine(_env.ContentRootPath, "wwwroot"));
			}
		}
	}
}
