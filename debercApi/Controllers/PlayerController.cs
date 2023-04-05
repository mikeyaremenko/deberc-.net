using debercApi.Models;
using debercApi.Services.PlayerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
            return Ok(_playerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var result = _playerService.Get(id);
            return (result is null) ? PlayerNotFound(id) : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Player>>> Add(Player player)
        {
            var result = _playerService.Add(player);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Player>>> Update(int id, Player requestPlayer)
        {
            var result = _playerService.Update(id, requestPlayer);
            return (result is null) ? PlayerNotFound(id) : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Player>>> Remove(int id)
        {
            var result = _playerService.Remove(id);
            return (result is null) ? PlayerNotFound(id) : Ok(result);
        }

        private NotFoundObjectResult PlayerNotFound(int id) => NotFound($"Player #{id} cannot be found :C");
    }
}
