using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.UploadFileCore.UseCases;

public class UcUploadFileEdit : UseCase, IUcUploadFileEdit
{
    private readonly IMediator _mediator;

    public UcUploadFileEdit(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(UploadFileEditCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }

    private static void HydrateValues(UploadFile target, UploadFile source)
    {
        target.Name = source.Name;
        target.Email = source.Email;
        target.Registration = source.Registration;
    }
}