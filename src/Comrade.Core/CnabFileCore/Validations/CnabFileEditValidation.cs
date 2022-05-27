using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileEditValidation : ICnabFileEditValidation
{
    public ISingleResult<Entity> Execute(CnabFile entity, CnabFile? recordExists)
    {
        return new SingleResult<Entity>(recordExists);
    }
}