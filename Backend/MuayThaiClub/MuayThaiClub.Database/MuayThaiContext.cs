using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MuayThaiClub.Database
{
  public class MuayThaiContext : IdentityDbContext
  {
    public MuayThaiContext(DbContextOptions options) : base(options)
    {
    }

    protected MuayThaiContext()
    {
    }
  }
}
