using CleanArchitecture.Application.Exercise.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ExerciseController : ApiControllerBase
{
    [HttpGet]
    [Route("category/{categoryId?}")]
    public async Task<ActionResult<List<ExerciseDto>>> GetExercises(int? categoryId)
    {
        return await Mediator.Send(new GetExerciseListQuery {CategoryId = categoryId});
    }
}