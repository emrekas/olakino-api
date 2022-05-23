using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.DietCategory.Queries;

public record GetDietCategoryListQuery : IRequest<List<DietCategoryDto>>;

public class GetDietCategoryListQueryHandler : IRequestHandler<GetDietCategoryListQuery, List<DietCategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDietCategoryListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DietCategoryDto>> Handle(GetDietCategoryListQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.DietCategories.AsNoTracking().ProjectTo<DietCategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}