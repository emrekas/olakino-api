using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.Diet.Queries;

public class DietDto: IMapFrom<Domain.Entities.Diet>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int DietCategoryId { get; set; }
}