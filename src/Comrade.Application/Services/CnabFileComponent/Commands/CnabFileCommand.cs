using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.cnabFileComponent.Commands;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Commands;

public class CnabFileCommand : ICnabFileCommand
{
    private readonly IUcCnabFileDelete _deleteCnabFile;
    private readonly IMediator _mediator;

    public CnabFileCommand(
        IUcCnabFileDelete deleteCnabFile, IMediator mediator)
    {
        _deleteCnabFile = deleteCnabFile;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(CnabFileCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(CnabFileEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteCnabFile.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}