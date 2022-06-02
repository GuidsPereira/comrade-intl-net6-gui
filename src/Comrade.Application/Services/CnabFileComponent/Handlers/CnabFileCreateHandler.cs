using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Core.CnabFileCore.Commands;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Handlers;

public class
    CnabFileCreateHandler : IRequestHandler<CnabFileCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcCnabFileCreate _createCnabFile;
    private readonly IMapper _mapper;

    public CnabFileCreateHandler(IMapper mapper, IUcCnabFileCreate createCnabFile)
    {
        _mapper = mapper;
        _createCnabFile = createCnabFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(CnabFileCreateDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<CnabFileCreateCommand>(request);
        var result = await _createCnabFile.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}