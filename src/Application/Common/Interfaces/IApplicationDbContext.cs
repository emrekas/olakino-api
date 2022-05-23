using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Exercise> Exercises { get; }
    DbSet<Domain.Entities.ExerciseCategory> ExerciseCategories { get; }
    DbSet<Domain.Entities.Diet> Diets { get; }
    DbSet<Domain.Entities.DietCategory> DietCategories { get; }
    DbSet<Domain.Entities.ActivityLog> ActivityLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
