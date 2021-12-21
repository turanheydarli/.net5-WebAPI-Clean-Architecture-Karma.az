using Business.Constants;
using Business.Handlers.Categories.ValidationRules;
using Business.Handlers.Images.Commands;
using Core.Aspects.Autofac.Validation;
using Core.Extentions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
	public class CreateCategoryCommand : IRequest<IResult>
	{
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

		public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
		{
			private ICategoryDal _categoryDal;
			private IMediator _mediator;

			public CreateCategoryCommandHandler(ICategoryDal categoryDal, IMediator mediator)
			{
				_categoryDal = categoryDal;
				_mediator = mediator;
			}

			[ValidationAspect(typeof(CreateCategoryValidator))]
			public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
			{
				var isThereAnyCategoty = await _categoryDal.GetAsync(c => c.Name == request.Name);

				if (isThereAnyCategoty != null)
				{
					return new ErrorResult(Messages.NameAlreadyExist);
				}

				var category = new Category
				{
					Name = request.Name,
					Icon = request.Icon,
					ParentId = request.ParentId,
					Image = await _mediator.Send(new UploadImageCommand { Photo = request.Photo }),
					CreatedAt = DateTime.UtcNow,
					Details = request.Details,
					MetaDescription = request.MetaDescription,
					TypeId = 1, //TODO: not working
					MetaKeywords = request.MetaKeywords,
					MetaTitle = request.MetaTitle,
					Slug = request.Name.GenerateSlug(),
				};

				_categoryDal.Add(category);
				await _categoryDal.SaveChangesAsync();
				return new SuccessResult();
			}
		}
	}
}
