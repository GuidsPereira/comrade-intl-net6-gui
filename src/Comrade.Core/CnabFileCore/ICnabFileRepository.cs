using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore;

public interface ICnabFileRepository : IRepository<CnabFile>
{
    IQueryable<Lookup>? FindByTipo(string tipo);
}