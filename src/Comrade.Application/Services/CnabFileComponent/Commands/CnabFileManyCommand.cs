using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.cnabFileComponent.Commands;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Commands;

public class CnabFileManyCommand : ICnabFileManyCommand
{
    private readonly IUcCnabFileManyDelete _deleteCnabFileMany;
    private readonly IMediator _mediator;

    public CnabFileManyCommand(
        IUcCnabFileManyDelete deleteCnabFileMany, IMediator mediator)
    {
        _deleteCnabFileMany = deleteCnabFileMany;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(CnabFileManyCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(CnabFileManyEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteCnabFileMany.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}