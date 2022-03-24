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
builder.Services.AddScoped<UserCourseStorage>();

builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
