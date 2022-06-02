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
    CnabFileManyDeleteCoreHandler : IRequestHandler<CnabFileManyDeleteCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ICnabFileManyRepository _repository;
    private readonly ICnabFileManyDeleteValidation _cnabFileManyDeleteValidation;

    public CnabFileManyDeleteCoreHandler(ICnabFileManyDeleteValidation cnabFileDeleteValidation,
        ICnabFileManyRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _cnabFileManyDeleteValidation = cnabFileDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileManyDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _cnabFileManyDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var systemUserId = recordExists.Id;
        _repository.Remove(systemUserId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(systemUserId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.DeleteOne<CnabFileMany>(systemUserId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}