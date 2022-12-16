using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodieBlog.Models;

public class FoodieContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeItem> RecipeItems { get; set; }

    public FoodieContext(DbContextOptions<FoodieContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Recipe>()
            .HasData(
            new Recipe
            {
                Id = 1,
                Name = "Shiitake and Pak Choi with Østerssauce",
                CookingSteps = "1) Wash Shiitake and Pak Choi." + "\n" + "2) Fry Shiitake with Østerssauce." + "\n" + "3) Fry Pak Choi together." + "\n" + "Done!",
                Introduction = "It is a deliouse dish and easily to make."
            }
            );

        builder.Entity<RecipeItem>()
                .HasData(
               new RecipeItem
               {
                   Id = 1,
                   Name = "Shiitake",
                   Amount = "50g",
                   RecipeId = 1,
               },

                new RecipeItem
                {
                    Id = 2,
                    Name = "Pak Choi",
                    Amount = "200g",
                    RecipeId = 1,
                },

                new RecipeItem
                {
                    Id = 3,
                    Name = "Østerssauce",
                    Amount = "20g",
                    RecipeId = 1,
                });
    }

}
