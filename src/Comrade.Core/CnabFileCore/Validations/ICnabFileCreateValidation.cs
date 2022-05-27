using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public interface ICnabFileCreateValidation
{
    ISingleResult<Entity> Execute(CnabFile entity);
}