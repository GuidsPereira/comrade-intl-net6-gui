using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.UploadFileComponent.Dtos;

namespace Comrade.Application.Services.UploadFileComponent.Queries;

public interface IUploadFileQuery
{
    Task<IPageResultDto<UploadFileDto>> GetAll(PaginationQuery? paginationQuery = null);
    Task<ISingleResultDto<UploadFileDto>> GetByIdDefault(Guid id);
    Task<ISingleResultDto<UploadFileDto>> GetByIdMongo(Guid id);
    Task<ListResultDto<LookupDto>> FindByName(string name);
}