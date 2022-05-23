namespace CleanArchitecture.Domain.Entities;

public class ExerciseCategory: AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<Exercise> Exercises { get; private set; } = new List<Exercise>();

}