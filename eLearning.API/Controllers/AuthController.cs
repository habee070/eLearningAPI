using eLearning.API.Controllers.BaseController;
using eLearning.Core.DTO.Authen;
using eLearning.Core.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eLearning.API.Controllers;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthenRequestDto authenRequestDto)
    {
        var result = await _authService.LoginAsync(authenRequestDto);
        if (result == null)
        {
            return BadRequestWithErrorMessage("Invalid username or password");
        }
        return Ok(result);
    }
}
