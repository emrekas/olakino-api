namespace CleanArchitecture.Domain.Entities;

public class DietCategory : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<Diet> Diets { get; private set; } = new List<Diet>();
}