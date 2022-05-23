using Comrade.Core.Bases.Interfaces;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Domain.Bases;

namespace Comrade.Core.UploadFileCore;

public interface IUcUploadFileCreate
{
    Task<ISingleResult<Entity>> Execute(UploadFileCreateCommand entity);
}