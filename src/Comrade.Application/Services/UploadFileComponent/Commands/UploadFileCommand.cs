using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.SystemUserComponent.Commands;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Comrade.Core.SystemUserCore;
using Comrade.Core.UploadFileCore;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Commands;

public class UploadFileCommand : IUploadFileCommand
{
    private readonly IUcUploadFileDelete _deleteUploadFile;
    private readonly IMediator _mediator;

    public UploadFileCommand(
        IUcUploadFileDelete deleteUploadFile, IMediator mediator)
    {
        _deleteUploadFile = deleteUploadFile;
        _mediator = mediator;
    }

    public async Task<ISingleResultDto<EntityDto>> Create(UploadFileCreateDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Edit(UploadFileEditDto dto)
    {
        return await _mediator.Send(dto).ConfigureAwait(false);
    }

    public async Task<ISingleResultDto<EntityDto>> Delete(Guid id)
    {
        var result = await _deleteUploadFile.Execute(id).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}