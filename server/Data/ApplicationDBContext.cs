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
    public DbSet<VideoGame> VideoGame { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Franchise> Franchise { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<VideoGameGenre> VideoGameGenre { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite keys
        builder.Entity<VideoGameGenre>(x => x.HasKey(p => new { p.GenreId, p.VideoGameId }));

        // video game & genre many-to-many relationship
        builder.Entity<VideoGameGenre>().HasOne(x => x.VideoGame).WithMany(x => x.VideoGameGenres).HasForeignKey(p => p.VideoGameId);
        builder.Entity<VideoGameGenre>().HasOne(x => x.Genre).WithMany(x => x.VideoGameGenres).HasForeignKey(p => p.GenreId);

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