using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkeletonBackend.API.Extensions;
using SkeletonBackend.Application.Library.Services;

namespace SkeletonBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly ILibraryService _libraryService;

    public LibraryController(ILibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    [HttpPost("{gameId:guid}")]
    public async Task<IActionResult> AddGame(Guid gameId, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        await _libraryService.AddGameAsync(userId, gameId, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetLibrary(CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var library = await _libraryService.GetLibraryAsync(userId, cancellationToken);
        return Ok(library);
    }
}
