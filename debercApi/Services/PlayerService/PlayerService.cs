using debercApi.Models;

namespace debercApi.Services.PlayerService;

public class PlayerService : IPlayerService
{
    private readonly DataContext _context;

    public PlayerService(DataContext context)
    {
        this._context = context;
    }

    public async Task<int?> Add(Player player)
    {
        var createdPlayer = _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return createdPlayer?.Entity.Id;
    }

    public async Task<Player?> Get(int id)
    {
        var players = await GetPlayers();
        return players.Find(p => p.Id == id);
    }

    public async Task<List<Player>> GetAll()
    {
        return await GetPlayers();
    }

    public async Task<bool> Remove(int id)
    {
        var players = await GetPlayers();
        var player = players.Find(p => p.Id == id);
        if (player is null)
            return false;

        players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, Player requestPlayer)
    {
        var players = await GetPlayers();
        var player = players.Find(p => p.Id == id);
        if (player is null)
            return false;

        player.Name = requestPlayer.Name;
        player.Password = requestPlayer.Password;
        player.Index = requestPlayer.Index;
        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<List<Player>> GetPlayers()
    {
        return await _context.Players.ToListAsync();
    }        
}

