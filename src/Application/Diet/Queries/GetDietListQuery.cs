using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Diet.Queries;

public record GetDietListQuery : IRequest<List<DietDto>>
{
    public int? CategoryId { get; set; }
}

public class GetDietListQueryHandler : IRequestHandler<GetDietListQuery, List<DietDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDietListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<DietDto>> Handle(GetDietListQuery request, CancellationToken cancellationToken)
    {
        var dietListQuery = _context.Diets.AsNoTracking();
        if (request.CategoryId.HasValue)
        {
            return await dietListQuery.Where(x => x.DietCategoryId == request.CategoryId)
                .ProjectTo<DietDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        return await dietListQuery
            .ProjectTo<DietDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}