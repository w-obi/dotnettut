using dotnettut.Data;
using dotnettut.Dtos;
using Microsoft.EntityFrameworkCore;

namespace dotnettut.Endpoints;

public static class GenreEndpoints
{
    const string genreEndpoint = "GetGenre";

    public static void MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Genres
        .Select(genre => new GenreDto(genre.Id, genre.Name))
        .AsNoTracking().ToListAsync()).WithName(genreEndpoint);
    }
}