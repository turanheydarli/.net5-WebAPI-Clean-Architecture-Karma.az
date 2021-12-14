using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			return Ok(await _categoryService.GetListAsync());
		}
	}
}
