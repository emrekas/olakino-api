using CleanArchitecture.Application.DietCategory.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class DietCategoryController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<DietCategoryDto>>> GetDietCategories()
    {
        return await Mediator.Send(new GetDietCategoryListQuery());
    }
}