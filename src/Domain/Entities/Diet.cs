namespace CleanArchitecture.Domain.Entities;

public class Diet: AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MealsJson { get; set; }
    public int TotalCalorie { get; set; }

    public int DietCategoryId { get; set; }
    public DietCategory DietCategory { get; set; }
}