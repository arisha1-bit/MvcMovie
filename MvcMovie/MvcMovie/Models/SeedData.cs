using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Mean Girls",
                    ReleaseDate = DateTime.Parse("2004-6-10"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Midsommar",
                    ReleaseDate = DateTime.Parse("2019-7-18"),
                    Genre = "Folk horror",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "8 Mile",
                    ReleaseDate = DateTime.Parse("2002-11-6"),
                    Genre = "Musical Drama",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Legaly Blonde",
                    ReleaseDate = DateTime.Parse("2001-10-11"),
                    Genre = "Romantic Comedy",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}