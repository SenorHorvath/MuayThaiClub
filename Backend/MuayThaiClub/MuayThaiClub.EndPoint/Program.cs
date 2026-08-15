
using Microsoft.EntityFrameworkCore;
using MuayThaiClub.Database;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic;

namespace MuayThaiClub.EndPoint
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddTransient(typeof(Repository<>));
      builder.Services.AddTransient<UserRepository>();
      builder.Services.AddTransient<UserLogic>();


      builder.Services.AddDbContext<MuayThaiContext>(opt =>
      {
        opt
        .UseSqlServer(builder.Configuration["ConnectionString"] ?? throw new Exception("No ConnectionString in appsettings.json"))
        .UseLazyLoadingProxies();
      });

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
    }
  }
}
