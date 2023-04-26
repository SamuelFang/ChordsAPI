using Microsoft.EntityFrameworkCore;
using ChordsAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ChordsAPIDBContext>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
