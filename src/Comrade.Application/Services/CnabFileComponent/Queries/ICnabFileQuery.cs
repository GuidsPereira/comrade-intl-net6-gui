using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.CnabFileComponent.Queries;

public interface ICnabFileQuery
{
    Task<IPageResultDto<CnabFileDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<CnabFileDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<CnabFileDto>> GetByIdMongo(Guid id);
    Task<ListResultDto<LookupDto>> FindByTipo(string tipo);
}