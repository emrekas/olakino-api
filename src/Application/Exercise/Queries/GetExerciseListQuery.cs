using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Exercise.Queries;

public record GetExerciseListQuery : IRequest<List<ExerciseDto>>
{
    public int? CategoryId { get; set; }
}

public class GetExerciseListQueryHandler : IRequestHandler<GetExerciseListQuery, List<ExerciseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<ExerciseDto>> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
    {
        var exerciseListQuery = _context.Exercises.AsNoTracking();
        if (request.CategoryId.HasValue)
        {
            return await exerciseListQuery.Where(x => x.ExerciseCategoryId == request.CategoryId)
                .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        return await exerciseListQuery
            .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}