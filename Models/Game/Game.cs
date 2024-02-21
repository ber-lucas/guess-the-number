using guessTheNumer.player;

namespace guessTheNumer.game;

public class Game {
  private Guid Id { get; init; }
  private List<Player> Players { get; } = [];
  private Guid? WinnerId { get; set; }
  private Player? Winner { get; set; }
  private DateTime PlayOn { get; init; }
  private DateTime EndedOn { get; set; }
  private int Moves { get; set; }

  public Game(List<Player> players) {
    Id = Guid.NewGuid();
    
    //Add players
    foreach(var p in players) {
      Players.Add(p);
    }

    PlayOn = DateTime.Now;
  }
}