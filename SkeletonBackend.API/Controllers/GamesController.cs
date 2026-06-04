using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkeletonBackend.Application.Games.Requests;
using SkeletonBackend.Application.Games.Services;

namespace SkeletonBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var games = await _gameService.GetAllAsync(cancellationToken);
        return Ok(games);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var game = await _gameService.GetByIdAsync(id, cancellationToken);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameRequest request, CancellationToken cancellationToken)
    {
        var game = await _gameService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }
}
