using debercApi.Models;

namespace debercApi.Services.PlayerService;

public class PlayerService : IPlayerService
{
    private static List<Player> players = new()
    {
        new Player { Id = 1, Name = "Mischa", Password = "secret", Index = 0 },
        new Player { Id = 2, Name = "Alex", Password = "secret", Index = 1 }
    };

    public List<Player> Add(Player player)
    {
        players.Add(player);
        return players;
    }

    public Player Get(int id)
    {
        var player = players.Find(p => p.Id == id);
        return player is null ? null : player;
    }

    public List<Player> GetAll()
    {
        return players;
    }

    public List<Player> Remove(int id)
    {
        var player = players.Find(p => p.Id == id);
        if (player is null)
            return null;

        players.Remove(player);
        return players;
    }

    public List<Player> Update(int id, Player requestPlayer)
    {
        var player = players.Find(p => p.Id == id);
        if (player is null)
            return null;

        player.Name = requestPlayer.Name;
        player.Password = requestPlayer.Password;
        player.Index = requestPlayer.Index;

        return players;
    }
}

