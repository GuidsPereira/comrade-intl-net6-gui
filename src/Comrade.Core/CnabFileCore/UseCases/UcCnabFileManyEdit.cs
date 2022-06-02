using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.CnabFileCore.UseCases;

public class UcCnabFileManyEdit : UseCase, IUcCnabFileManyEdit
{
    private readonly IMediator _mediator;

    public UcCnabFileManyEdit(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(CnabFileManyEditCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }

    private static void HydrateValues(CnabFileMany target, CnabFileMany source)
    {
    }
}