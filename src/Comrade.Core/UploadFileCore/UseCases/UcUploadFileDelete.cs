using Comrade.Core.Bases;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Domain.Bases;
using MediatR;

namespace Comrade.Core.UploadFileCore.UseCases;

public class UcUploadFileDelete : UseCase, IUcUploadFileDelete
{
    private readonly IMediator _mediator;

    public UcUploadFileDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ISingleResult<Entity>> Execute(Guid id)
    {
        var entity = new UploadFileDeleteCommand {Id = id};
        return await _mediator.Send(entity).ConfigureAwait(false);
    }
}