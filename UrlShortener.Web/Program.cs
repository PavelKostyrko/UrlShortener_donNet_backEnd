using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("UrlDbConnection");

builder.Services.AddDbContext<UrlDbContext>(options => {
    options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 3)));
});

builder.Services.AddTransient<UrlDbContext>();
builder.Services.AddTransient<IUrlService, UrlService>();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/", () => "Shortener"); 

app.Run();
