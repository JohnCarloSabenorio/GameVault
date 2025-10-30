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
    public DbSet<Engine> Engine { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Collection> Collection { get; set; }
    public DbSet<Developer> Developer { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Mode> Mode { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Video> Video { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Platform> Platform { get; set; }
    public DbSet<GameGenre> GameGenre { get; set; }
    public DbSet<GameEngine> GameEngine { get; set; }
    public DbSet<GameMode> GameMode { get; set; }
    public DbSet<GameDeveloper> GameDeveloper { get; set; }
    public DbSet<GamePublisher> GamePublisher { get; set; }
    public DbSet<GameCollection> GameCollection { get; set; }
    public DbSet<GameLanguage> GameLanguage { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite keys
        builder.Entity<GameGenre>(x => x.HasKey(p => new { p.GenreId, p.GameId }));
        builder.Entity<GameDeveloper>(x => x.HasKey(p => new { p.GameId, p.DeveloperId }));
        builder.Entity<GamePublisher>(x => x.HasKey(p => new { p.GameId, p.PublisherId }));
        builder.Entity<GameCollection>(x => x.HasKey(p => new { p.CollectionId, p.GameId }));
        builder.Entity<GameLanguage>(x => x.HasKey(p => new { p.GameId, p.LanguageId }));
        builder.Entity<GameEngine>(x => x.HasKey(p => new { p.GameId, p.EngineId }));
        builder.Entity<GameMode>(x => x.HasKey(p => new { p.GameId, p.ModeId }));

        // Many-to-many Relationship
        builder.Entity<GameGenre>().HasOne(x => x.Game).WithMany(x => x.GameGenre).HasForeignKey(p => p.GameId);
        builder.Entity<GameGenre>().HasOne(x => x.Genre).WithMany(x => x.GameGenre).HasForeignKey(p => p.GenreId);

        builder.Entity<GameDeveloper>().HasOne(x => x.Game).WithMany(x => x.GameDeveloper).HasForeignKey(p => p.GameId);
        builder.Entity<GameDeveloper>().HasOne(x => x.Developer).WithMany(x => x.GameDeveloper).HasForeignKey(p => p.DeveloperId);

        builder.Entity<GamePublisher>().HasOne(x => x.Game).WithMany(x => x.GamePublisher).HasForeignKey(p => p.GameId);
        builder.Entity<GamePublisher>().HasOne(x => x.Publisher).WithMany(x => x.GamePublisher).HasForeignKey(p => p.PublisherId);

        builder.Entity<GameCollection>().HasOne(x => x.Game).WithMany(x => x.GameCollection).HasForeignKey(p => p.GameId);
        builder.Entity<GameCollection>().HasOne(x => x.Collection).WithMany(x => x.GameCollection).HasForeignKey(p => p.CollectionId);

        builder.Entity<GameLanguage>().HasOne(x => x.Game).WithMany(x => x.GameLanguage).HasForeignKey(p => p.GameId);
        builder.Entity<GameLanguage>().HasOne(x => x.Language).WithMany(x => x.GameLanguage).HasForeignKey(p => p.LanguageId);

        builder.Entity<GameEngine>().HasOne(x => x.Game).WithMany(x => x.GameEngine).HasForeignKey(p => p.GameId);
        builder.Entity<GameEngine>().HasOne(x => x.Engine).WithMany(x => x.GameEngine).HasForeignKey(p => p.EngineId);

        builder.Entity<GameMode>().HasOne(x => x.Game).WithMany(x => x.GameMode).HasForeignKey(p => p.GameId);
        builder.Entity<GameMode>().HasOne(x => x.Mode).WithMany(x => x.GameMode).HasForeignKey(p => p.ModeId);

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