using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Comrade.Core.SystemUserCore;
using Comrade.Core.SystemUserCore.Commands;
using Comrade.Core.UploadFileCore;
using Comrade.Core.UploadFileCore.Commands;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Handlers;

public class UploadFileEditHandler : IRequestHandler<UploadFileEditDto, SingleResultDto<EntityDto>>
{
    private readonly IUcUploadFileEdit _editUploadFile;
    private readonly IMapper _mapper;

    public UploadFileEditHandler(IMapper mapper, IUcUploadFileEdit editUploadFile)
    {
        _mapper = mapper;
        _editUploadFile = editUploadFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(UploadFileEditDto request,
        CancellationToken cancellationToken)
    {
        var mappedObject = _mapper.Map<UploadFileEditCommand>(request);
        var result = await _editUploadFile.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}