using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.UploadFileComponent.Dtos;

using Comrade.Core.UploadFileCore;
using Comrade.Core.UploadFileCore.Commands;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Handlers;

public class
    UploadFileCreateHandler : IRequestHandler<UploadFileCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcUploadFileCreate _createUploadFile;
    private readonly IMapper _mapper;

    public UploadFileCreateHandler(IMapper mapper, IUcUploadFileCreate createUploadFile)
    {
        _mapper = mapper;
        _createUploadFile = createUploadFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(UploadFileCreateDto request,
        CancellationToken cancellationToken)
    {

        

        var mappedObject = _mapper.Map<UploadFileCreateCommand>(request);
        var result = await _createUploadFile.Execute(mappedObject).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}