using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.CnabFileCore;

public interface IUcCnabFileManyCreate
{
    Task<ISingleResult<Entity>> Execute(CnabFileManyCreateCommand entity);
}