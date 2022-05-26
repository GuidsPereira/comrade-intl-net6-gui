using System.ComponentModel.DataAnnotations;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.UploadFileComponent.Commands;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Queries;
using Microsoft.AspNetCore.Http;

namespace Comrade.Api.UseCases.V1.UploadFileApi;

// [Authorize]
[FeatureGate(CustomFeature.UploadFile)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UploadFileController : ControllerBase
{
    private readonly IUploadFileCommand _uploadFileCommand;
    private readonly IUploadFileQuery _uploadFileQuery;

    public UploadFileController(IUploadFileCommand uploadFileCommand,
        IUploadFileQuery uploadFileQuery)
    {
        _uploadFileCommand = uploadFileCommand;
        _uploadFileQuery = uploadFileQuery;
    }


    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _uploadFileQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }


    [HttpGet("get-by-id/{uploadFileId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute] [Required] Guid uploadFileId)
    {
        try
        {
            var result = await _uploadFileQuery.GetByIdDefault(uploadFileId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("create")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public async Task<IActionResult> Create([FromBody] [Required] UploadFileCreateDto dto)
    {
        try
        {
            var result = await _uploadFileCommand.Create(dto).ConfigureAwait(false);

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
    public async Task<IActionResult> Edit([FromBody] [Required] UploadFileEditDto dto)
    {
        try
        {
            var result = await _uploadFileCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{uploadFileId:int}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute] [Required] Guid uploadFileId)
    {
        try
        {
            var result = await _uploadFileCommand.Delete(uploadFileId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}