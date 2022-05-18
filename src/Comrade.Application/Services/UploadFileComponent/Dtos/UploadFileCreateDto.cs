using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Dtos;

public class UploadFileCreateDto : UploadDto, IRequest<SingleResultDto<EntityDto>>
{
}