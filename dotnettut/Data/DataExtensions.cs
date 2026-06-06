using Microsoft.EntityFrameworkCore;
using dotnettut.Models;

namespace dotnettut.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreContext(this WebApplicationBuilder builder)
    {
        var connstr = builder.Configuration.GetConnectionString("GameStore");

        builder.Services.AddSqlite<GameStoreContext>(connstr, optionsAction: options => options.UseSeeding((context, _) =>
        {
            if (!context.Set<Genre>().Any())
            {
                context.Set<Genre>().AddRange(
                    new Genre { Name = "Fighting" },
                    new Genre { Name = "Rpg" },
                    new Genre { Name = "Platformer" },
                    new Genre { Name = "Racing" },
                    new Genre { Name = "Sports" }
                );

                context.SaveChanges();
            }
        }));
    }
}