using System.ComponentModel.DataAnnotations;
using guessTheNumer.game;

namespace guessTheNumer.player;

public class Player {
  public Guid Id { get; init; }

  [StringLength(50, MinimumLength = 3)]
  [Required]
  public string Name { get; private set; }
  public List<Game> Games { get; }
  public List<Game> Victories { get; }
  public int Moves { get; private set; }

  public Player() {}
  public Player(string name) {
    Id = Guid.NewGuid();
    Name = name;
    Moves = 0;
    Games = new List<Game>();
    Victories = new List<Game>();
  }
}