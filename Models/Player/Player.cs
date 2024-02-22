using guessTheNumer.game;

namespace guessTheNumer.player;

public class Player {
  public Guid Id { get; init; }
  private string Name { get; set; }
  public List<Game> Games { get; } = [];
  public List<Game> Victories { get; } = [];
  private int Moves { get; set; }

  public Player() {}
  public Player(string name) {
    Id = Guid.NewGuid();
    Name = name;
  }
}