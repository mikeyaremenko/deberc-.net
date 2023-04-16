using debercApi.Models;
namespace debercApi.Services.PlayerService;

public interface IPlayerService
{
    Task<List<Player>> GetAll();
    Task<Player?> Get(int id);
    Task<int?> Add(Player player);
    Task<bool> Update(int id, Player requestPlayer);
    Task<bool> Remove(int id);
}

