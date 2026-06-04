using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkeletonBackend.Application.Builds.Requests;
using SkeletonBackend.Application.Builds.Services;

namespace SkeletonBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BuildsController : ControllerBase
{
    private readonly IBuildService _buildService;

    public BuildsController(IBuildService buildService)
    {
        _buildService = buildService;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(
        [FromForm] Guid gameId,
        [FromForm] string version,
        [FromForm] string changelog,
        [FromForm] string executablePath,
        IFormFile file,
        CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty.");
        }

        using var stream = file.OpenReadStream();
        var request = new UploadBuildRequest(
            gameId,
            version,
            stream,
            file.FileName,
            executablePath,
            changelog);

        var build = await _buildService.UploadAsync(request, cancellationToken);
        return Ok(build);
    }

    [AllowAnonymous]
    [HttpGet("latest/{gameId:guid}")]
    public async Task<IActionResult> GetLatest(Guid gameId, CancellationToken cancellationToken)
    {
        var build = await _buildService.GetLatestAsync(gameId, cancellationToken);
        if (build == null)
        {
            return NotFound();
        }
        return Ok(build);
    }
}
