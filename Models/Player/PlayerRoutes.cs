using guessTheNumer.data;

namespace guessTheNumer.player;

public record PlayerRequest(string Name);
public record PlayerResponse(string Message, Player Player);
public static class PlayerRoutes {
  public static void AddPlayerRoutes(this WebApplication app) {
    var playerRoute = app.MapGroup("players");

    playerRoute.MapPost("", async (PlayerRequest request, AppDbContext context) => {
      var newPlayer = new Player(request.Name);

      try {
        await context.Players.AddAsync(newPlayer);
        await context.SaveChangesAsync();
      } catch (Exception) {
        throw new Exception("Error: Unable to create player!");
      }

      var response = new PlayerResponse("Successfully created player!", newPlayer);
      
      return response;
    });
  }
}