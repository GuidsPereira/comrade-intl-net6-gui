using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.CnabFileCore;

public interface IUcCnabFileManyDelete
{
    Task<ISingleResult<Entity>> Execute(Guid id);
}