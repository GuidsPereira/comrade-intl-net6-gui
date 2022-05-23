using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.UploadFileCore;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.UploadFileCore.UseCases;

public class UcUploadFileCreate : UseCase, IUcUploadFileCreate
{
    private readonly IMediator _mediator;

    public UcUploadFileCreate(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(UploadFileCreateCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}