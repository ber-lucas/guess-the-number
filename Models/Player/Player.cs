using guessTheNumer.game;

namespace guessTheNumer.player;

public class Player {
  private Guid Id { get; init; }
  private string Name { get; set; }
  private List<Game> Games { get; } = [];
  private List<Game> Victories { get; } = [];
  private int Moves { get; set; }

  public Player(string name) {
    Id = Guid.NewGuid();
    Name = name;
  }
}