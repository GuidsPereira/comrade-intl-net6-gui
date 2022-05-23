using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public interface IUploadFilePasswordValidation
{
    ISingleResult<UploadFile> Execute(Guid key, string password);
}