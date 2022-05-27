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
    CnabFileCreateCoreHandler : IRequestHandler<CnabFileCreateCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICnabFileRepository _repository;
    private readonly ICnabFileCreateValidation _cnabFileCreateValidation;

    public CnabFileCreateCoreHandler(ICnabFileCreateValidation cnabFileCreateValidation,
        ICnabFileRepository repository, IMongoDbCommandContext mongoDbContext,
        IPasswordHasher passwordHasher)
    {
        _cnabFileCreateValidation = cnabFileCreateValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileCreateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = _cnabFileCreateValidation.Execute(request);
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