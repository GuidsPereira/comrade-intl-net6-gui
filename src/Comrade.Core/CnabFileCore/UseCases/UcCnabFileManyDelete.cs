using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.CnabFileCore.UseCases;

public class UcCnabFileManyDelete : UseCase, IUcCnabFileManyDelete
{
    private readonly IMediator _mediator;

    public UcCnabFileManyDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new CnabFileManyDeleteCommand { Id = id };
        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}