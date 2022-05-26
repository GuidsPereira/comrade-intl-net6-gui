using System.Threading;
using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.Messages;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Core.UploadFileCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.UploadFileCore.Handlers;

public class
    UploadFileEditCoreHandler : IRequestHandler<UploadFileEditCommand, ISingleResult<Entity>>
{
    private readonly IMongoDbCommandContext _mongoDbContext;
    private readonly IUploadFileRepository _repository;
    private readonly IUploadFileEditValidation _uploadFileEditValidation;

    public UploadFileEditCoreHandler(IUploadFileEditValidation uploadFileEditValidation,
        IUploadFileRepository repository, IMongoDbCommandContext mongoDbContext)
    {
        _uploadFileEditValidation = uploadFileEditValidation;
        _repository = repository;
        _mongoDbContext = mongoDbContext;
    }

    public async Task<ISingleResult<Entity>> Handle(UploadFileEditCommand request,
        CancellationToken cancellationToken)
    {
        var recordExists = await _repository.GetById(request.Id).ConfigureAwait(false);

        if (recordExists is null)
        {
            return new DeleteResult<Entity>(false,
                BusinessMessage.MSG04);
        }

        var result = _uploadFileEditValidation.Execute(request, recordExists);
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

    private static void HydrateValues(UploadFile target, UploadFile source)
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