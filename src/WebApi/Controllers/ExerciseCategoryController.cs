using CleanArchitecture.Application.ExerciseCategory.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ExerciseCategoryController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ExerciseCategoryDto>>> GetExerciseCategories()
    {
        return await Mediator.Send(new GetExerciseCategoryListQuery());
    }
}