using Comrade.Core.Bases.Interfaces;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.CnabFileCore;

public interface IUcCnabFileManyEdit
{
    Task<ISingleResult<Entity>> Execute(CnabFileManyEditCommand entity);
}