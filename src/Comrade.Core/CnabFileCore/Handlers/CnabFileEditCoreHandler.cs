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
    CnabFileEditCoreHandler : IRequestHandler<CnabFileEditCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly ICnabFileRepository _repository;
    private readonly ICnabFileEditValidation _cnabFileEditValidation;

    public CnabFileEditCoreHandler(ICnabFileEditValidation cnabFileEditValidation,
        ICnabFileRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _cnabFileEditValidation = cnabFileEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(CnabFileEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var result = _cnabFileEditValidation.Execute(request, recordExists);
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

    private static void HydrateValues(CnabFile target, CnabFile source)
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