namespace CleanArchitecture.Domain.Entities;

public class Exercise: AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ExerciseCategoryId { get; set; }
    public ExerciseCategory ExerciseCategory { get; set; }
}