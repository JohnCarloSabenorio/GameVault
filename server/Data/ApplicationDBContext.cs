using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using server.Models;

namespace server.Data;


public class ApplicationDBContext : IdentityDbContext<User>
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Review> Review { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Franchise> Franchise { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Developer> Developer { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<GamePlatform> GamePlatform { get; set; }
    public DbSet<GameGenre> GameGenre { get; set; }
    public DbSet<GameCollection> GameCollection { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite keys
        builder.Entity<GameGenre>(x => x.HasKey(p => new { p.GenreId, p.GameId }));

        // game & genre many-to-many relationship
        builder.Entity<GameGenre>().HasOne(x => x.Game).WithMany(x => x.GameGenre).HasForeignKey(p => p.GameId);
        builder.Entity<GameGenre>().HasOne(x => x.Genre).WithMany(x => x.GameGenre).HasForeignKey(p => p.GenreId);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
            Id = "1",
            Name = "Admin",
            NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
            Id = "2",
            Name = "User",
            NormalizedName = "USER",
            },
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}