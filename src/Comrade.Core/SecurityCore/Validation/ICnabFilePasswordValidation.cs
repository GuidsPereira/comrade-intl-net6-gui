using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public interface ICnabFilePasswordValidation
{
    ISingleResult<CnabFile> Execute(Guid key, string password);
}