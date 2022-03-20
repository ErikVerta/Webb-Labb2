using Microsoft.EntityFrameworkCore;
using Webb_Labb2.DAL;
using AppContext = Webb_Labb2.DAL.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Labb2Database");
    options.UseSqlServer(connectionString);
});

builder.Services.AddSingleton<CourseStorage>();
builder.Services.AddSingleton<UserStorage>();
builder.Services.AddSingleton<DifficultyStorage>();

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
