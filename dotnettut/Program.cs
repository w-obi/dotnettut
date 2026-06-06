using dotnettut.Endpoints;
using dotnettut.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreContext();

var app = builder.Build();

app.MapGameEndpoints();
app.MapGenreEndpoints();
app.MigrateDb();
app.Run();
