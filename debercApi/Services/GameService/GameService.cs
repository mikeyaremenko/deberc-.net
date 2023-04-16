using debercApi.Models;
using System.ComponentModel;

namespace debercApi.Services.GameService;

public class GameService : IGameService
{
    private readonly DataContext _context;

    public GameService(DataContext context)
    {
        _context = context;
    }

    public async Task<Game?> Get(int id)
    {       
        return await FindGame(id);
    }

    public async Task<List<Game>> GetAll()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<int?> Create(Game game)
    {
        game.Status = GameStatus.Created;
        var createdGame = await _context.Games.AddAsync(game);
        return createdGame?.Entity.Id;
    }

    public async Task<bool> Start(int id)
    {
        return await ChangeGameStatus(id, GameStatus.Started);
    }

    public async Task<bool> Finish(int id)
    {
        return await ChangeGameStatus(id, GameStatus.Finished);
    }

    private async Task<bool> ChangeGameStatus(int id, GameStatus gameStatus)
    {
        var game = await FindGame(id);
        if (game == null)
            return false;

        game.Status = gameStatus;
        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<Game?> FindGame(int id)
    {
        return await _context.Games.FindAsync(id);
    }
}
