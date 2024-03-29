using guessTheNumer.game;
using guessTheNumer.player;
using Microsoft.EntityFrameworkCore;

namespace guessTheNumer.data;

public class AppDbContext : DbContext {
  public DbSet<Player> Players { get; set; }
  public DbSet<Game> Games { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseSqlite("Data Source=db.sqlite");
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    var playerEntity = modelBuilder.Entity<Player>();
    var gameEntity = modelBuilder.Entity<Game>();
    
    playerEntity.HasKey(e => e.Id);

    gameEntity.HasKey(e => e.Id);
    
    playerEntity.HasMany(e => e.Games)
      .WithMany(e => e.Players);

    playerEntity.HasMany(e => e.Victories)
      .WithOne(e => e.Winner)
      .HasForeignKey(e => e.WinnerId)
      .IsRequired(false);

    base.OnModelCreating(modelBuilder);
  }
}