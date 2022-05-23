using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.SystemUserCore.Validations;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Core.UploadFileCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Extensions;
using MediatR;

namespace Comrade.Core.UploadFileCore.Handlers;

public class
    UploadFileCreateCoreHandler : IRequestHandler<UploadFileCreateCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUploadFileRepository _repository;
    private readonly IUploadFileCreateValidation _uploadFileCreateValidation;

    public UploadFileCreateCoreHandler(IUploadFileCreateValidation uploadFileCreateValidation,
        IUploadFileRepository repository, IMongoDbCommandContext mongoDbContext,
        IPasswordHasher passwordHasher)
    {
        _uploadFileCreateValidation = uploadFileCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<ISingleResult<Entity>> Handle(UploadFileCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = _uploadFileCreateValidation.Execute(request);
        if (!validate.Success)
        {
            return validate;
        }

        //request.Password = _passwordHasher.Hash(request.Password);
        //request.RegisterDate = DateTimeBrasilia.GetDateTimeBrasilia();

        await _repository.Add(request).ConfigureAwait(false);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        await _repository.Add(request).ConfigureAwait(false);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        return new CreateResult<Entity>(true,
            BusinessMessage.MSG01);
    }
}