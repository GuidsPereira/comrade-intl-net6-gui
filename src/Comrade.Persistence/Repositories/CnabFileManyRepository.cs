using Comrade.Core.CnabFileCore;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;

namespace Comrade.Persistence.Repositories;

public class CnabFileManyRepository : Repository<CnabFileMany>, ICnabFileManyRepository
{
    private readonly ComradeContext _context;

    public CnabFileManyRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }


    public IQueryable<Lookup>? FindByName(string name)
    {
        var result = _context.SystemUsers //(Criar o CnabFiles)
            .Where(x => x.Name.Contains(name)).Take(30)
            .OrderBy(x => x.Name)
            .Select(s => new Lookup { Key = s.Id, Value = s.Name });

        return result;
    }
}