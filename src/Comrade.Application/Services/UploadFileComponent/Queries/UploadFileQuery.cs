using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Comrade.Core.SystemUserCore;
using Comrade.Core.UploadFileCore;
using Comrade.Domain.Models;

namespace Comrade.Application.Services.UploadFileComponent.Queries;

public class UploadFileQuery : IUploadFileQuery
{
    private readonly IMapper _mapper;
    private readonly IMongoDbQueryContext _mongoDbQueryContext;
    private readonly IUploadFileRepository _repository;

    public UploadFileQuery(IUploadFileRepository repository,
        IMongoDbQueryContext mongoDbQueryContext, IMapper mapper)
    {
        _repository = repository;
        _mongoDbQueryContext = mongoDbQueryContext;
        _mapper = mapper;
    }

    public async Task<IPageResultDto<UploadFileDto>> GetAll(
        PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = _mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);

        List<UploadFileDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => _repository.GetAllAsNoTracking()
                .ProjectTo<UploadFileDto>(_mapper.ConfigurationProvider)
                .ToList()).ConfigureAwait(false);

            return new PageResultDto<UploadFileDto>(list);
        }

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        list = await Task.Run(() => _repository.GetAllAsNoTracking().Skip(skip)
            .Take(paginationFilter.PageSize)
            .ProjectTo<UploadFileDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new PageResultDto<UploadFileDto>(paginationFilter, list);
    }

    public async Task<ListResultDto<LookupDto>> FindByName(string name)
    {
        var list = await Task.Run(() => _repository.FindByName(name)
            .ProjectTo<LookupDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new ListResultDto<LookupDto>(list);
    }

    public async Task<ISingleResultDto<UploadFileDto>> GetByIdDefault(Guid id)
    {
        var entity = await _repository.GetById(id).ConfigureAwait(false);
        var dto = _mapper.Map<UploadFileDto>(entity);
        return new SingleResultDto<UploadFileDto>(dto);
    }

    public async Task<ISingleResultDto<UploadFileDto>> GetByIdMongo(Guid id)
    {
        var entity = await _mongoDbQueryContext.GetById<UploadFile?>(id).ConfigureAwait(false);
        var dto = _mapper.Map<UploadFileDto>(entity);
        return new SingleResultDto<UploadFileDto>(dto);
    }
}