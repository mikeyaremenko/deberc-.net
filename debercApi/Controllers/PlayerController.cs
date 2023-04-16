using debercApi.Models;
using debercApi.Services.PlayerService;
using Microsoft.AspNetCore.Mvc;

namespace debercApi.Controllers
{
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
            var result = await _playerService.Get(id);
            return (result is null) ? PlayerNotFound(id) : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int?>> Add(Player player)
        {
            var result = await _playerService.Add(player);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, Player requestPlayer)
        {
            var result = await _playerService.Update(id, requestPlayer);
            return result ? Ok(result) : PlayerNotFound(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Player>>> Remove(int id)
        {
            var result = await _playerService.Remove(id);
            return result ? Ok(result) : PlayerNotFound(id);
        }

        private NotFoundObjectResult PlayerNotFound(int id) => NotFound($"Player #{id} cannot be found :C");
    }
}
