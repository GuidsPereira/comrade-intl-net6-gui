using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Core.CnabFileCore.Validations;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.CnabFileCore.Handlers;

public class
    CnabFileDeleteCoreHandler : IRequestHandler<CnabFileDeleteCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ICnabFileRepository _repository;
    private readonly ICnabFileDeleteValidation _cnabFileDeleteValidation;

    public CnabFileDeleteCoreHandler(ICnabFileDeleteValidation cnabFileDeleteValidation,
        ICnabFileRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _cnabFileDeleteValidation = cnabFileDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _cnabFileDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var systemUserId = recordExists.Id;
        _repository.Remove(systemUserId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(systemUserId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.DeleteOne<CnabFile>(systemUserId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}