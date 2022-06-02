using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.CnabFileCore.UseCases;

public class UcCnabFileManyCreate : UseCase, IUcCnabFileManyCreate
{
    private readonly IMediator _mediator;

    public UcCnabFileManyCreate(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(CnabFileManyCreateCommand entity)
    {
        var isValid = ValidateEntity(entity);
        if (!isValid.Success)
        {
            return isValid;
        }

        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}