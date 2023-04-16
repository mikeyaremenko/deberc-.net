using debercApi.Models;
using debercApi.Services.PlayerService;
using Microsoft.AspNetCore.Mvc;

namespace debercApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Player>>> GetAll()
    {
        var players = await _playerService.GetAll();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> Get(int id)
    {
        var player = await _playerService.Get(id);
        return (player is null) ? PlayerNotFound(id) : Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<int?>> Add(Player player)
    {
        var id = await _playerService.Add(player);
        return (id is null) ? BadRequest($"Player could not be created") : Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update(int id, Player requestPlayer)
    {
        var isUpdated = await _playerService.Update(id, requestPlayer);
        return isUpdated ? Ok(isUpdated) : PlayerNotFound(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Player>>> Remove(int id)
    {
        var isRemoved = await _playerService.Remove(id);
        return isRemoved ? Ok(isRemoved) : PlayerNotFound(id);
    }

    private NotFoundObjectResult PlayerNotFound(int id) => NotFound($"Player #{id} cannot be found :C");
}
