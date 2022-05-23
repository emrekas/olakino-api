using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.Exercise.Queries;

public class ExerciseDto: IMapFrom<Domain.Entities.Exercise>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ExerciseCategoryId { get; set; }
}