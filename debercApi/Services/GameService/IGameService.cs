using debercApi.Models;

namespace debercApi.Services.GameService;

public interface IGameService
{
    Task<Game?> Get(int id);
    Task<List<Game>> GetAll();
    Task<int?> Create(Game game);
    Task<bool> Finish(Game game);

}
