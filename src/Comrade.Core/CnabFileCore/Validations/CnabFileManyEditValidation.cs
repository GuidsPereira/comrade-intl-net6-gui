using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileManyEditValidation : ICnabFileManyEditValidation
{
    public ISingleResult<Entity> Execute(CnabFileMany entity, CnabFileMany? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}