using Business.Handlers.Images.ValidationRules;
using Business.Services.File;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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
	public class UploadImageCommand : IRequest<Image>
	{
		public IFormFile Photo { get; set; }

		class UploadImageQueryHandler : IRequestHandler<UploadImageCommand, Image>
		{
			private readonly IImageDal _imageDal;
			private readonly IFileService _fileService;
			IHostEnvironment _env;

			public UploadImageQueryHandler(IFileService fileService, IImageDal imageDal, IHostEnvironment env)
			{
				_fileService = fileService;
				_imageDal = imageDal;
				_env = env;
			}

			[ValidationAspect(typeof(UploadImageValidator))]
			public async Task<Image> Handle(UploadImageCommand request, CancellationToken cancellationToken)
			{
				return await _fileService.SaveImage(request.Photo, Path.Combine(_env.ContentRootPath, "wwwroot"));
			}
		}
	}
}
