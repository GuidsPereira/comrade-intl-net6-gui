using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Core.CnabFileCore.Commands;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Handlers;

public class CnabFileManyEditHandler : IRequestHandler<CnabFileManyEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcCnabFileManyEdit _editCnabFileMany;
    private readonly IMapper _mapper;

    public CnabFileManyEditHandler(IMapper mapper, IUcCnabFileManyEdit editCnabFileMany)
    {
        _mapper = mapper;
        _editCnabFileMany = editCnabFileMany;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(CnabFileManyEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<CnabFileManyEditCommand>(request);
        var result = await _editCnabFileMany.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}