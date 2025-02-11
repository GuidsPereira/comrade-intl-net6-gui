using Comrade.Application.Bases;
using Comrade.Application.Services.AuthenticationServices.Commands;
using Comrade.Application.Services.AuthenticationServices.Dtos;
using Microsoft.AspNetCore.Http;

namespace Comrade.Api.UseCases.V1.LoginApi;

[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationCommand _authenticationCommand;

    public AuthenticationController(IAuthenticationCommand authenticationCommand)
    {
        _authenticationCommand = authenticationCommand;
    }

    [HttpPost("update-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SingleResultDto<EntityDto>),
        StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdatePassword([FromBody] AuthenticationDto dto)
    {
        try
        {
            var result = await _authenticationCommand.UpdatePassword(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SingleResultDto<EntityDto>),
        StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ForgotPassword([FromBody] AuthenticationDto dto)
    {
        try
        {
            var result = await _authenticationCommand.ForgotPassword(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}