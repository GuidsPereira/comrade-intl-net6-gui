using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore;

public interface IUploadFileRepository : IRepository<UploadFile>
{
    IQueryable<Lookup>? FindByName(string name);
}