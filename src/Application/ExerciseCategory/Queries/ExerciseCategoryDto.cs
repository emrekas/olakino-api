using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.ExerciseCategory.Queries;

public class ExerciseCategoryDto : IMapFrom<Domain.Entities.ExerciseCategory>
{
    public int Id { get; set; }
    public string Name { get; set; }
}