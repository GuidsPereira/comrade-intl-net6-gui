using Comrade.Core.CnabFileCore;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;

namespace Comrade.Persistence.Repositories;

public class CnabFileRepository : Repository<CnabFile>, ICnabFileRepository
{
    private readonly ComradeContext _context;

    public CnabFileRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }


    public IQueryable<Lookup>? FindByTipo(string tipo)
    {
        var result = _context.CnabFiles //(Criar o CnabFiles)
            .Where(x => x.Tipo.Contains(tipo)).Take(30)
            .OrderBy(x => x.Tipo)
            .Select(s => new Lookup { Key = s.Id, Value = s.Tipo });

        return result;
    }
}