using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Core.CnabFileCore.Commands;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Handlers;

public class CnabFileEditHandler : IRequestHandler<CnabFileEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcCnabFileEdit _editCnabFile;
    private readonly IMapper _mapper;

    public CnabFileEditHandler(IMapper mapper, IUcCnabFileEdit editCnabFile)
    {
        _mapper = mapper;
        _editCnabFile = editCnabFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(CnabFileEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<CnabFileEditCommand>(request);
        var result = await _editCnabFile.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}