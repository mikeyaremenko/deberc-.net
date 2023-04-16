using debercApi.Models;

namespace debercApi.Services.GameService;

public interface IGameService
{
    Task<Game?> Get(int id);
    Task<List<Game>> GetAll();
    Task<int?> Create(Game game);
    Task<bool> Start(int id);
    Task<bool> Finish(int id);

}
