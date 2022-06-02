using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore;

public interface ICnabFileManyRepository : IRepository<CnabFileMany>
{
    IQueryable<Lookup>? FindByName(string name);
}