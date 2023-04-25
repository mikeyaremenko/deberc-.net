using debercApi.Models;
using debercApi.Services.GameService;
using Microsoft.AspNetCore.Mvc;

namespace debercApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetAll()
    {
        var games = await _gameService.GetAll();
        return games;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> Get(int id)
    {
        var game = await _gameService.Get(id);
        return (game is null) ? GameNotFound(id) : Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(Game game)
    {
        var id = await _gameService.Create(game);
        return (id is null) ? BadRequest($"Game could not be created") : Ok(id);
    }

    [HttpPut("{id}/start")]
    public async Task<ActionResult<bool>> Start(int id)
    {
        var isStarted = await _gameService.Start(id);
        return (isStarted) ? Ok(id) : GameNotFound(id);
    }

    [HttpPut("{id}/finish")]
    public async Task<ActionResult<bool>> Finish(int id)
    {
        var isFinished = await _gameService.Finish(id);
        return (isFinished) ? Ok(id) : GameNotFound(id);
    }

    private NotFoundObjectResult GameNotFound(int id) => NotFound($"Player #{id} cannot be found :C");
}
