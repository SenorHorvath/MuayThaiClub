using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Model.Objects;

namespace MuayThaiClub.Database
{
  public class MuayThaiContext : IdentityDbContext
  {
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public MuayThaiContext(DbContextOptions options) : base(options)
    {
      //Database.EnsureDeleted();
      //Database.EnsureCreated();
    }

    protected MuayThaiContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<Comment>().
        HasOne(c => c.Post)
        .WithMany(p => p.Comments)
        .HasForeignKey(c => c.PostID)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Comment>().
        HasMany(c => c.Replies)
        .WithOne(p => p.ParentComment)
        .HasForeignKey(p => p.ParentCommentID)
        .OnDelete(DeleteBehavior.NoAction);
      base.OnModelCreating(builder);

    }
  }
}
