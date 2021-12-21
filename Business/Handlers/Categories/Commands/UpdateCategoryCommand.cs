using AutoMapper;
using Business.Constants;
using Business.Handlers.Images.Commands;
using Core.Extentions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Commands
{
	public class UpdateCategoryCommand : IRequest<IResult>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Icon { get; set; }
		public string Details { get; set; }
		public string MetaTitle { get; set; }
		public string MetaDescription { get; set; }
		public string MetaKeywords { get; set; }
		public int? ParentId { get; set; }
		public int TypeId { get; set; }
		public bool IsDeactive { get; set; }
		public IFormFile Photo { get; set; }


		public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
		{
			private readonly ICategoryDal _categoryDal;
			private readonly IMediator _mediator;

			public UpdateCategoryCommandHandler(IMediator mediator, ICategoryDal categoryDal)
			{
				_mediator = mediator;
				_categoryDal = categoryDal;
			}

			public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
			{
				var categoryToUpdate = await _categoryDal.GetAsync(c => c.Id == request.Id);

				categoryToUpdate.Name = request.Name;
				categoryToUpdate.Slug = request.Slug == null ? request.Name.GenerateSlug() : request.Slug;
				categoryToUpdate.ParentId = request.ParentId;
				categoryToUpdate.Details = request.Details;
				categoryToUpdate.Icon = request.Icon;
				categoryToUpdate.IsDeactive = request.IsDeactive;
				categoryToUpdate.MetaDescription = request.MetaDescription;
				categoryToUpdate.MetaKeywords = request.MetaKeywords;
				categoryToUpdate.MetaTitle = request.MetaTitle;
				categoryToUpdate.UpdatedAt = DateTime.Now;

				if (request.Photo != null)
					categoryToUpdate.Image = await _mediator.Send(new UpdateImageCommand
					{
						ImageId = (int)categoryToUpdate.ImageId,
						File = request.Photo
					});

				await _categoryDal.SaveChangesAsync();

				return new SuccessResult(Messages.Updated);
			}
		}
	}
}
