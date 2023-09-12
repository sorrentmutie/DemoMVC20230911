using Corso.APIMinimal;
using Corso.Core.DTO;
using Corso.Core.Entities.Movies;
using Corso.Core.Interfaces;
using Corso.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
   o => o.UseInMemoryDatabase("Movies"));
builder.Services.AddScoped<IMovieData, MovieData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var genres = app.MapGroup("/genres");

genres.MapGet("/", async (IMovieData data) => await data.GetGenres() );
genres.MapGet("/{id}", async (IMovieData data, int id) =>
{
    return await data.GetById(id)
    is GenreDTO dto
    ? Results.Ok(dto)
    : Results.NotFound();
});
genres.MapPost("/", async (IMovieData data, [FromBody] GenreDTOCreation genre) => {
    if (genre == null) return Results.BadRequest();
    var genreDTO = await data.CreateGenre(genre);
    return Results.Created($"/genres/{genreDTO.Id}", genreDTO);
});
genres.MapPut("/{id}", async (IMovieData data, int id, GenreDTOCreation genreDTO) =>
{
    if(genreDTO == null) return Results.BadRequest();
    return await data.Update(id, genreDTO)
    is GenreDTO dto
    ? Results.NoContent()
    : Results.NotFound();
});

genres.MapDelete("/{id}", async (IMovieData data, int id) =>
{
    return await data.Delete(id)
    ? Results.NoContent()
    : Results.NotFound();
});

var movies = app.MapGroup("/movies");
movies.MapPost("/", async (IMovieData data, [FromBody] Movie movie) => {
    if (movie == null) return Results.BadRequest();
    movie.Id = await data.CreateMovie(movie);
    return Results.Created($"/movies/{movie.Id}", new MovieDTO
    {
        Id = movie.Id
    });
});
movies.MapGet("/{id}", async (IMovieData data, int id) =>
{
    return await data.GetMovieById(id)
    is MovieDTO movie
    ? Results.Ok(movie)
    : Results.NotFound();
}); 


app.Run();


