using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;

namespace Comrade.Core.UploadFileCore;

public interface IUcUploadFileDelete
{
    Task<ISingleResult<Entity>> Execute(Guid id);
}