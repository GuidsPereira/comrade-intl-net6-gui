using System.ComponentModel.DataAnnotations;
using Comrade.Api.Bases;
using Comrade.Api.Modules.Common;
using Comrade.Api.Modules.Common.FeatureFlags;
using Comrade.Application.Bases;
using Comrade.Application.Paginations;
using Comrade.Application.Services.cnabFileComponent.Commands;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Application.Services.CnabFileComponent.Queries;
using Microsoft.AspNetCore.Http;

namespace Comrade.Api.UseCases.V1.CnabFileApi;

// [Authorize]
[FeatureGate(CustomFeature.CnabFile)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class CnabFileController : ComradeController
{
    private readonly ICnabFileCommand _cnabFileCommand;
    private readonly ICnabFileQuery _cnabFileQuery;
    private readonly ICnabFileManyCommand _cnabFileManyCommand;
    private readonly ICnabFileManyQuery _cnabFileManyQuery;

    public CnabFileController(ICnabFileCommand cnabFileCommand,
        ICnabFileQuery cnabFileQuery, ICnabFileManyCommand cnabFileManyCommand, ICnabFileManyQuery cnabFileManyQuery)
    {
        _cnabFileCommand = cnabFileCommand;
        _cnabFileQuery = cnabFileQuery;
        _cnabFileManyCommand = cnabFileManyCommand;
        _cnabFileManyQuery = cnabFileManyQuery;
    }


    [HttpGet("get-all")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery? paginationQuery)
    {
        try
        {
            var result = await _cnabFileQuery.GetAll(paginationQuery).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }


    [HttpGet("get-by-id/{cnabFileId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
    public async Task<IActionResult> GetById([FromRoute] [Required] Guid cnabFileId)
    {
        try
        {
            var result = await _cnabFileQuery.GetByIdDefault(cnabFileId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpGet("lookup-cnab-file-by-tipo/{tipo}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
    public async Task<IActionResult> GetLookupCnabFileByTipo(string tipo)
    {
        try
        {
            var result = await _cnabFileQuery.FindByTipo(tipo).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpPost("create-many")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
    public async Task<IActionResult> CreateMany([FromBody] [Required] CnabFileManyCreateDto dto)
    {
        try
        {
            var result = await _cnabFileManyCommand.Create(dto).ConfigureAwait(false);

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
    public async Task<IActionResult> Create([FromBody] [Required] CnabFileCreateDto dto)
    {
        try
        {
            var result = await _cnabFileCommand.Create(dto).ConfigureAwait(false);

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
    public async Task<IActionResult> Edit([FromBody] [Required] CnabFileEditDto dto)
    {
        try
        {
            var result = await _cnabFileCommand.Edit(dto).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }

    [HttpDelete("delete/{cnabFileId:Guid}")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
    public async Task<IActionResult> Delete([FromRoute] [Required] Guid cnabFileId)
    {
        try
        {
            var result = await _cnabFileCommand.Delete(cnabFileId).ConfigureAwait(false);
            return StatusCode(result.Code, result);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new SingleResultDto<EntityDto>(e));
        }
    }
}