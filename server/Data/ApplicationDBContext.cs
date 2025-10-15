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

    public DbSet<UserReview> UserReview { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserReview>(x => x.HasKey(ur => new { ur.UserId, ur.ReviewId }));

        builder.Entity<UserReview>().HasOne(ur => ur.User).WithMany(u => u.UserReviews).HasForeignKey(ur => ur.UserId);
        builder.Entity<UserReview>().HasOne(ur => ur.Review).WithMany(u => u.UserReviews).HasForeignKey(ur => ur.ReviewId);


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