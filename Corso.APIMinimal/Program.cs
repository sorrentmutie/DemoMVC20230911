using Corso.APIMinimal;
using Corso.APIMinimal.Configurations;
using Corso.Core.DTO;
using Corso.Core.Entities.Movies;
using Corso.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration, 
       typeof(IServiceInstaller).Assembly);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseOutputCache();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var genres = app.MapGroup("/genres");

genres.MapGet
    ("/", async (IMovieData data) => await data.GetGenres())
    .CacheOutput(x => x.Tag("genres"));
genres.MapGet("/{id}", async (IMovieData data, int id) =>
{
    return await data.GetById(id)
    is GenreDTO dto
    ? Results.Ok(dto)
    : Results.NotFound();
}).CacheOutput(x => x.SetVaryByQuery("id").Expire(TimeSpan.FromSeconds(60)));


genres.MapPost("/", async (IMovieData data, 
    [FromBody] GenreDTOCreation genre,
    IOutputCacheStore cache, CancellationToken ct) => {
    if (genre == null) return Results.BadRequest();
    var genreDTO = await data.CreateGenre(genre);
    await cache.EvictByTagAsync("genres", ct);
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


