using CleanArchitecture.Application.Diet.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class DietController : ApiControllerBase
{
    [HttpGet]
    [Route("category/{categoryId?}")]
    public async Task<ActionResult<List<DietDto>>> GetDiets(int? categoryId)
    {
        return await Mediator.Send(new GetDietListQuery{CategoryId = categoryId});
    }
}