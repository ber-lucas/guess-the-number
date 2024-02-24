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
        response = await context
            .Players
            .Where(player => player.Active)
            .ToListAsync();
      } catch (Exception) {
        throw new Exception("Error: Unable to return all players!");
      }

      return Results.Ok(response);
    });

    //Delete Player Route
    playerRoute.MapDelete("{id:guid}", async (Guid id, AppDbContext context) => {
      var player = await context
        .Players
        .SingleOrDefaultAsync(player => player.Id == id);

      if(player == null) {
        return Results.NotFound("Player not found!");
      }

      player.DisablePlayer();

      try {
        await context.SaveChangesAsync();
      } catch(Exception) {
        throw new Exception("Unable to disable player!");
      }

      return Results.Ok("Player successfully deleted!");
    });    
  }
}