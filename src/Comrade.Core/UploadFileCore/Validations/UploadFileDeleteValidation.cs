using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore.Validations;

public class UploadFileDeleteValidation : IUploadFileDeleteValidation
{
    public ISingleResult<Entity> Execute(UploadFile? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}