using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.ExerciseCategory.Queries;

public record GetExerciseCategoryListQuery : IRequest<List<ExerciseCategoryDto>>;

public class
    GetExerciseCategoryListQueryHandler : IRequestHandler<GetExerciseCategoryListQuery, List<ExerciseCategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseCategoryListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExerciseCategoryDto>> Handle(GetExerciseCategoryListQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.ExerciseCategories.AsNoTracking()
            .ProjectTo<ExerciseCategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}