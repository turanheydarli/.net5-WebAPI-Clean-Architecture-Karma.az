using Business.Constants;
using Business.Handlers.Images.Commands;
using Core.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Images.ValidationRules
{
	public class UploadImageValidator : AbstractValidator<UploadImageCommand>
	{
		public UploadImageValidator()
		{
			RuleFor(i => i.Photo).NotNull().NotEmpty();

			RuleFor(i => i.Photo).Must(IsImage)
				.WithMessage(Messages.InvalidFile);

			//RuleFor(i => i.Photo).Must(CheckIfMaxLength)
			//	.WithMessage(Messages.FileLengthError);

		}

		private bool CheckIfMaxLength(IFormFile file)
		{
			return file.Length < Convert.ToInt64(FileLengthSize.Image);
		}

		private bool IsImage(IFormFile file)
		{
			return file.ContentType.Contains("image/");
		}
	}
}

