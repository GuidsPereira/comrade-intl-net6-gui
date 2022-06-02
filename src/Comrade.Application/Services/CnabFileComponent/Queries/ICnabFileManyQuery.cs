using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.CnabFileComponent.Queries;

public interface ICnabFileManyQuery
{
    Task<IPageResultDto<CnabFileManyDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<CnabFileManyDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<CnabFileManyDto>> GetByIdMongo(Guid id);
    Task<ListResultDto<LookupDto>> FindByName(string name);
}