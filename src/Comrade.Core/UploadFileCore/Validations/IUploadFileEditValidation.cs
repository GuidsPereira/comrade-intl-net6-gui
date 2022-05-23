using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore.Validations;

public interface IUploadFileEditValidation
{
    ISingleResult<Entity> Execute(UploadFile entity, UploadFile? recordExists);
}