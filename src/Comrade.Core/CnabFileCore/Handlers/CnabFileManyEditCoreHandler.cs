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
    CnabFileManyEditCoreHandler : IRequestHandler<CnabFileManyEditCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ICnabFileManyRepository _repository;
    private readonly ICnabFileManyEditValidation _cnabFileManyEditValidation;

    public CnabFileManyEditCoreHandler(ICnabFileManyEditValidation cnabFileEditValidation,
        ICnabFileManyRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _cnabFileManyEditValidation = cnabFileEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileManyEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var result = _cnabFileManyEditValidation.Execute(request, recordExists);
        if (!result.Success)
        {
            return result;
        }

        var obj = recordExists;

        HydrateValues(obj, request);

        _repository.Update(obj);

        await _repository.BeginTransactionAsync().ConfigureAwait(false);
        _repository.Update(obj);
        await _repository.CommitTransactionAsync().ConfigureAwait(false);

        _mongoDbContext.ReplaceOne(obj);

        return new EditResult<Entity>(true,
            BusinessMessage.MSG02);
    }

    private static void HydrateValues(CnabFileMany target, CnabFileMany source)
    {
        target.Tipo = source.Tipo;
        target.Data = source.Data;
        target.Valor = source.Valor;
        target.CPF = source.CPF;
        target.Cartao = source.Cartao;
        target.Hora = source.Hora;
        target.DonoLoja = source.DonoLoja;
        target.NomeLoja = source.NomeLoja;
    }
}