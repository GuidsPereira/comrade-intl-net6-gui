using System.ComponentModel.DataAnnotations;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemUserComponent.Commands;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.SystemUserComponent.Queries;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Microsoft.AspNetCore.Http;

namespace Comrade.Api.UseCases.V1.SystemUserApi;

// [Authorize]
[FeatureGate(CustomFeature.SystemUser)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UploadFileController : ControllerBase
{
    private readonly IUploadFileCommand _systemUserCommand;
    private readonly ISystemUserQuery _systemUserQuery;

    public UploadFileController(IUploadFileCommand systemUserCommand,
        ISystemUserQuery systemUserQuery)
    {
        _systemUserCommand = systemUserCommand;
        _systemUserQuery = systemUserQuery;
    }


    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _systemUserQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }


    [HttpGet("get-by-id/{systemUserId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute] [Required] Guid systemUserId)
    {
        try
        {
            var result = await _systemUserQuery.GetByIdDefault(systemUserId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("teste-post-gui")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public IActionResult TestePostGui([FromBody] [Required] UploadFileCreateDto dto)
    {
        try
        {
            var result = new ResultDto();
            result.Code = 200;
            result.Message = dto.Info; //>tostring?
            result.Success = true;

            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPut("edit")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
    public async Task<IActionResult> Edit([FromBody] [Required] SystemUserEditDto dto)
    {
        try
        {
            var result = await _systemUserCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{systemUserId:int}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute] [Required] Guid systemUserId)
    {
        try
        {
            var result = await _systemUserCommand.Delete(systemUserId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}