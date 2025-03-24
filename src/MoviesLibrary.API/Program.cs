using MoviesLibrary.Infrastructure;
using MoviesLibrary.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();

var app = builder.Build();

app.UsePresentation();

app.Run();