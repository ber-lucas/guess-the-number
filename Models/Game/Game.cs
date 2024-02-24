using guessTheNumer.player;
using Microsoft.EntityFrameworkCore;

namespace guessTheNumer.game;

public class Game {
  public Guid Id { get; init; }
  public List<Player> Players { get; }
  public Guid? WinnerId { get; private set; }
  public Player? Winner { get; private set; }
  public DateTime PlayOn { get; init; }
  public DateTime? EndedOn { get; private set; }
  public int Moves { get; private set; }
  public int TargetNumber { get; init; }

  public Game() {}
  public Game(List<Player> players) {
    Id = Guid.NewGuid();
    Players = [ .. players ];
    WinnerId = null;
    Winner = null;
    PlayOn = DateTime.Now;
    EndedOn = null;
    Moves = 0;
    TargetNumber = new Random().Next(0, 100);
  }
}