using AutoMapper;
using AutoMapper.QueryableExtensions;
using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Lookups;
using Comrade.Application.Paginations;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Domain.Models;

namespace Comrade.Application.Services.CnabFileComponent.Queries;

public class CnabFileManyQuery : ICnabFileManyQuery
{
    private readonly IMapper _mapper;
    private readonly IMongoDbQueryContext _mongoDbQueryContext;
    private readonly ICnabFileManyRepository _repository;

    public CnabFileManyQuery(ICnabFileManyRepository repository,
        IMongoDbQueryContext mongoDbQueryContext, IMapper mapper)
    {
        _repository = repository;
        _mongoDbQueryContext = mongoDbQueryContext;
        _mapper = mapper;
    }

    public async Task<IPageResultDto<CnabFileManyDto>> GetAll(
        PaginationQuery? paginationQuery = null)
    {
        var paginationFilter = _mapper.Map<PaginationQuery?, PaginationFilter?>(paginationQuery);

        List<CnabFileManyDto> list;
        if (paginationFilter == null)
        {
            list = await Task.Run(() => _repository.GetAllAsNoTracking()
                .ProjectTo<CnabFileManyDto>(_mapper.ConfigurationProvider)
                .ToList()).ConfigureAwait(false);

            return new PageResultDto<CnabFileManyDto>(list);
        }

        var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        list = await Task.Run(() => _repository.GetAllAsNoTracking().Skip(skip)
            .Take(paginationFilter.PageSize)
            .ProjectTo<CnabFileManyDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new PageResultDto<CnabFileManyDto>(paginationFilter, list);
    }

    public async Task<ListResultDto<LookupDto>> FindByName(string name)
    {
        var list = await Task.Run(() => _repository.FindByName(name)
            .ProjectTo<LookupDto>(_mapper.ConfigurationProvider)
            .ToList()).ConfigureAwait(false);

        return new ListResultDto<LookupDto>(list);
    }

    public async Task<ISingleResultDto<CnabFileManyDto>> GetByIdDefault(Guid id)
    {
        var entity = await _repository.GetById(id).ConfigureAwait(false);
        var dto = _mapper.Map<CnabFileManyDto>(entity);
        return new SingleResultDto<CnabFileManyDto>(dto);
    }

    public async Task<ISingleResultDto<CnabFileManyDto>> GetByIdMongo(Guid id)
    {
        var entity = await _mongoDbQueryContext.GetById<CnabFileMany?>(id).ConfigureAwait(false);
        var dto = _mapper.Map<CnabFileManyDto>(entity);
        return new SingleResultDto<CnabFileManyDto>(dto);
    }
}