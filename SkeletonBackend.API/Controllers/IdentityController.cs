using Microsoft.AspNetCore.Mvc;
using SkeletonBackend.Application.Identity.Requests;
using SkeletonBackend.Application.Identity.Services;

namespace SkeletonBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        await _identityService.RegisterAsync(request, cancellationToken);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await _identityService.LoginAsync(request, cancellationToken);
        return Ok(response);
    }
}
