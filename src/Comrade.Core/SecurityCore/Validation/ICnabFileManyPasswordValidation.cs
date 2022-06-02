using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public interface ICnabFileManyPasswordValidation
{
    ISingleResult<CnabFileMany> Execute(Guid key, string password);
}