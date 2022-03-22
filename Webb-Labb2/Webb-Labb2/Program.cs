using Microsoft.EntityFrameworkCore;
using Webb_Labb2.DAL;
using Labb2Context = Webb_Labb2.DAL.Labb2Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Labb2Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Labb2Database");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<CourseStorage>();
builder.Services.AddScoped<UserStorage>();
builder.Services.AddScoped<DifficultyStorage>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
