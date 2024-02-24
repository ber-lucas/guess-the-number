using guessTheNumer.data;
using Microsoft.EntityFrameworkCore;

namespace guessTheNumer.player;

public static class PlayerRoutes {
  public static void AddPlayerRoutes(this WebApplication app) {
    var playerRoute = app.MapGroup("players");

    // Create Player Route
    playerRoute.MapPost("", async (CreatePlayerRequest request, AppDbContext context) => {
      var newPlayer = new Player(request.Name);

      try {
        await context.Players.AddAsync(newPlayer);
        await context.SaveChangesAsync();
      } catch (Exception) {
        throw new Exception("Error: Unable to create player!");
      }
      
      return Results.Ok(newPlayer);
    });

    //Get all players Route
    playerRoute.MapGet("", async (AppDbContext context) => {
      List<Player> response;
      
      try {
        response = await context.Players.ToListAsync();
      } catch (Exception) {
        throw new Exception("Error: Unable to return all players!");
      }

      return Results.Ok(response);
    });    
  }
}