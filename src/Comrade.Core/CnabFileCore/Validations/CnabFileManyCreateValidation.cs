using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileManyCreateValidation : ICnabFileManyCreateValidation
{
    public ISingleResult<Entity> Execute(CnabFileMany entity)
    {
        return new SingleResult<Entity>(entity);
    }
}