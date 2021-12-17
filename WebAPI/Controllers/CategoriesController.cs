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

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : BaseApiController
	{

		[HttpGet("getall")]
		public async Task<IActionResult> GetList()
		{
			return GetResponseOnlyResultData(await Mediator.Send(new GetCategoriesQuery()));
		}

		[HttpGet("getbyid")]
		public async Task<IActionResult> GetById(int id)
		{
			return GetResponseOnlyResultData(await Mediator.Send(new GetCategoryQuery { Id = id}));
		}

	}
}
