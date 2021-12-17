using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using MediatR;

namespace Business.Handlers.Categories.Queries
{
	public class GetCategoriesQuery : IRequest<IDataResult<IEnumerable<CategoryDto>>>
	{
		public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
		{
			private readonly ICategoryDal _categoryDal;
			private readonly IMapper _mapper;

			public GetCategoriesQueryHandler(ICategoryDal categoryDal, IMapper mapper)
			{
				_categoryDal = categoryDal;
				_mapper = mapper;
			}

			public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
			{
				var categoryList = await _categoryDal.GetListAsync(null, c => c.Type, c => c.Image);
				var categoryDtoList = categoryList.Select(category => _mapper.Map<CategoryDto>(category)).ToList();

				return new SuccessDataResult<IEnumerable<CategoryDto>>(categoryDtoList);
			}
		}
	}
}