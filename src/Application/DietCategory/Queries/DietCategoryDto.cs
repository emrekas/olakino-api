using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.DietCategory.Queries;

public class DietCategoryDto: IMapFrom<Domain.Entities.DietCategory>
{
    public int Id { get; set; }
    public string Name { get; set; }
}