using AutoMapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.Queries
{
	public class GetCategoryQuery : IRequest<IDataResult<CategoryDto>>
	{
		public int Id { get; set; }

		public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IDataResult<CategoryDto>>
		{
			private readonly IMapper _mapper;
			private readonly ICategoryDal _categoryDal;

			public GetCategoryQueryHandler(ICategoryDal categoryDal, IMapper mapper)
			{
				_categoryDal = categoryDal;
				_mapper = mapper;
			}

			public async Task<IDataResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
			{
				var category = await _categoryDal.GetAsync(c => c.Id == request.Id, c => c.Type, c => c.Image);
				var categoryDto = _mapper.Map<CategoryDto>(category);

				return new SuccessDataResult<CategoryDto>(categoryDto);
			}
		}
	}
}
