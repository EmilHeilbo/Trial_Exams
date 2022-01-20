namespace Trial_3.Data;

using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

public class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        AppDbContext ctx = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<AppDbContext>();
        if (ctx.Database.GetPendingMigrations().Any())
            ctx.Database.Migrate();
        if (!ctx.Products.Any())
        {
            ctx.Products.AddRange(
                new Product { Name = "Pasta", Price = 90m },
                new Product { Name = "Pizza", Price = 70m },
                new Product { Name = "Rice", Price = 50m });
            ctx.SaveChanges();
        }
    }
}