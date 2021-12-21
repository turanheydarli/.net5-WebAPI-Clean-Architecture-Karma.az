using Business.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Business.Handlers.Categories.Queries;
using Business.Handlers.Categories.Commands;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : BaseApiController
	{
		[HttpPost]
		public async Task<IActionResult> GetList()
		{
			return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return GetResponseOnlyResultData(await Mediator.Send(new GetCategoryQuery { Id = id }));
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromForm] CreateCategoryCommand createCategory)
		{
			return GetResponseOnlyResultMessage(await Mediator.Send(createCategory));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromForm] UpdateCategoryCommand updateCategory, int id)
		{
			updateCategory.Id = id;
			return GetResponseOnlyResultMessage(await Mediator.Send(updateCategory));
		}

	}
}
