using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileCreateValidation : ICnabFileCreateValidation
{
    public ISingleResult<Entity> Execute(CnabFile entity)
    {
        return new SingleResult<Entity>(entity);
    }
}