namespace CleanArchitecture.Domain.Entities;

public class ActivityLog : AuditableEntity
{
    public int Id { get; set; }
    public DateTime BeginDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int CaloriesBurned { get; set; }
    
    public int ExerciseId { get; set; }

    public Exercise Exercise { get; set; }

}