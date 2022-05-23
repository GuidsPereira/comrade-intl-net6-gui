using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.SystemUserCore.Validations;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Core.UploadFileCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.UploadFileCore.Handlers;

public class
    UploadFileDeleteCoreHandler : IRequestHandler<UploadFileDeleteCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IUploadFileRepository _repository;
    private readonly IUploadFileDeleteValidation _uploadFileDeleteValidation;

    public UploadFileDeleteCoreHandler(IUploadFileDeleteValidation uploadFileDeleteValidation,
        IUploadFileRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _uploadFileDeleteValidation = uploadFileDeleteValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(UploadFileDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var validate = _uploadFileDeleteValidation.Execute(recordExists);
        if (!validate.Success)
        {
            return validate;
        }

        var systemUserId = recordExists.Id;
        _repository.Remove(systemUserId);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Remove(systemUserId);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.DeleteOne<UploadFile>(systemUserId);

        return new DeleteResult<Entity>(true,
            BusinessMessage.MSG03);
    }
}