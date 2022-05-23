using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore.Validations;

public class UploadFileCreateValidation : IUploadFileCreateValidation
{
    public ISingleResult<Entity> Execute(UploadFile entity)
    {
        return new SingleResult<Entity>(entity);
    }
}