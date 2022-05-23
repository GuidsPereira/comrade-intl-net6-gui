using Comrade.Core.SystemUserCore;
using Comrade.Core.UploadFileCore;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using Comrade.Persistence.Bases;
using Comrade.Persistence.DataAccess;

namespace Comrade.Persistence.Repositories;

public class UploadFileRepository : Repository<UploadFile>, IUploadFileRepository
{
    private readonly ComradeContext _context;

    public UploadFileRepository(ComradeContext context)
        : base(context)
    {
        _context = context ??
                   throw new ArgumentNullException(nameof(context));
    }


    public IQueryable<Lookup>? FindByName(string name)
    {
        var result = _context.SystemUsers //(Criar o UploadFiles)
            .Where(x => x.Name.Contains(name)).Take(30)
            .OrderBy(x => x.Name)
            .Select(s => new Lookup {Key = s.Id, Value = s.Name});

        return result;
    }
}