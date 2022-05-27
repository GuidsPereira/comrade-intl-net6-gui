using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileDeleteValidation : ICnabFileDeleteValidation
{
    public ISingleResult<Entity> Execute(CnabFile? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}