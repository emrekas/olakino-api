﻿using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator =
            new ApplicationUser {FirstName = "Emre", UserName = "administrator@localhost", Email = "administrator@localhost"};

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new[] {administratorRole.Name});
        }
        //
        // var dietCategory = new DietCategory {Id = 1, Name = "Ketojenik"};
        //
        // var diet = new Diet {Name = "Alafortanfoni", MealsJson = "{}", DietCategoryId = dietCategory.Id, TotalCalorie = 456};
        //
        // var exerciseCategory = new ExerciseCategory {Id = 1, Name = "Chest"};
        //
        // var exercise = new Exercise {Name = "Bench Press", ExerciseCategoryId = exerciseCategory.Id};
        //
        // _context.Add(dietCategory);
        // _context.Add(diet);
        // _context.Add(exerciseCategory);
        // _context.Add(exercise);
        
        await _context.SaveChangesAsync();
    }
}