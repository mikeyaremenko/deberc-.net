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
        var createdPlayer = await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        return createdPlayer?.Entity.Id;
    }

    public async Task<Player?> Get(int id)
    {
        return await FindPlayer(id);
    }

    public async Task<List<Player>> GetAll()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<bool> Remove(int id)
    {
        var player = await FindPlayer(id);
        if (player is null)
            return false;

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, Player requestPlayer)
    {
        var player = await FindPlayer(id);
        if (player is null)
            return false;

        player.Name = requestPlayer.Name;
        player.Password = requestPlayer.Password;
        player.Index = requestPlayer.Index;
        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<Player?> FindPlayer(int id)
    {
        return await _context.Players.FindAsync(id);
    }
}

