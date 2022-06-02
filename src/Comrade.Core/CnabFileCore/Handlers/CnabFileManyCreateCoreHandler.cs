using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Core.CnabFileCore.Validations;
using Comrade.Core.Messages;
using Comrade.Domain.Bases;
using Comrade.Domain.Extensions;
using MediatR;

namespace Comrade.Core.CnabFileCore.Handlers;

public class
    CnabFileManyCreateCoreHandler : IRequestHandler<CnabFileManyCreateCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICnabFileManyRepository _repository;
    private readonly ICnabFileManyCreateValidation _cnabFileManyCreateValidation;

    public CnabFileManyCreateCoreHandler(ICnabFileManyCreateValidation cnabFileManyCreateValidation,
        ICnabFileManyRepository repository, IMongoDbCommandContext mongoDbContext,
        IPasswordHasher passwordHasher)
    {
        _cnabFileManyCreateValidation = cnabFileManyCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileManyCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = _cnabFileManyCreateValidation.Execute(request);
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