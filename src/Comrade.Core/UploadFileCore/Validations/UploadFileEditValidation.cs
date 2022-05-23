using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore.Validations;

public class UploadFileEditValidation : IUploadFileEditValidation
{
    public ISingleResult<Entity> Execute(UploadFile entity, UploadFile? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}