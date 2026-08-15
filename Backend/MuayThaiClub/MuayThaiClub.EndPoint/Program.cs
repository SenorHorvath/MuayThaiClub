
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MuayThaiClub.Database;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.EndPoint.Helpers;
using MuayThaiClub.Logic;
using System.Text;

namespace MuayThaiClub.EndPoint
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers(opt =>
      {
        opt.Filters.Add<ExceptionFilter>();
      });
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen(option =>
      {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "MuayThai API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          In = ParameterLocation.Header,
          Description = "Please enter a valid token",
          Name = "Authorization",
          Type = SecuritySchemeType.Http,
          BearerFormat = "JWT",
          Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
      });

      builder.Services.AddTransient(typeof(Repository<>));
      builder.Services.AddTransient<UserLogic>();


      builder.Services.AddIdentity<AppUser, IdentityRole>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<MuayThaiContext>()
               .AddDefaultTokenProviders();

      builder.Services.AddAuthentication(option =>
      {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = "movieclub.com",
          ValidIssuer = "movieclub.com",
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"] ?? throw new Exception("jwt:key not found in appsettings.json")))
          //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcsNagyonhosszútitkosítókulcs"))
        };
      });

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
