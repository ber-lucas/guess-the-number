using guessTheNumer.player;
using Microsoft.EntityFrameworkCore;

namespace guessTheNumer.game;

public class Game {
  
  public Guid Id { get; init; }
  public List<Player> Players { get; } = [];
  public Guid? WinnerId { get; set; }
  public Player? Winner { get; set; }
  private DateTime PlayOn { get; init; }
  private DateTime EndedOn { get; set; }
  private int Moves { get; set; }

  public Game() {}
  public Game(List<Player> players) {
    Id = Guid.NewGuid();
    
    //Add players
    foreach(var p in players) {
      Players.Add(p);
    }

    PlayOn = DateTime.Now;
  }
}