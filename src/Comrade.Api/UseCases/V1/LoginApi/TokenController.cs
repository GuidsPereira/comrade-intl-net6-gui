using Comrade.Application.Bases;
using Comrade.Application.Services.AuthenticationServices.Commands;
using Comrade.Application.Services.AuthenticationServices.Dtos;
using Microsoft.AspNetCore.Http;

namespace Comrade.Api.UseCases.V1.LoginApi;

[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticationCommand _authenticationCommand;

    public TokenController(IAuthenticationCommand authenticationCommand)
    {
        _authenticationCommand = authenticationCommand;
    }


    [HttpPost("generate-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SingleResultDto<EntityDto>),
        StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GenerateToken([FromBody] AuthenticationDto dto)
    {
        try
        {
            var result = await _authenticationCommand.GenerateToken(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}