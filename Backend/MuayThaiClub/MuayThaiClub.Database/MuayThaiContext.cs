using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuayThaiClub.Database.Helpers;

namespace MuayThaiClub.Database
{
  public class MuayThaiContext : IdentityDbContext
  {
    public DbSet<AppUser> AppUsers { get; set; }
    public MuayThaiContext(DbContextOptions options) : base(options)
    {
      Database.EnsureCreated();
    }

    protected MuayThaiContext()
    {
    }
  }
}
