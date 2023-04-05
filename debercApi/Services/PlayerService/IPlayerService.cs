using debercApi.Models;
namespace debercApi.Services.PlayerService;

public interface IPlayerService
{
    List<Player> GetAll();
    Player Get(int id);
    List<Player> Add(Player player);
    List<Player> Update(int id, Player requestPlayer);
    List<Player> Remove(int id);
}

