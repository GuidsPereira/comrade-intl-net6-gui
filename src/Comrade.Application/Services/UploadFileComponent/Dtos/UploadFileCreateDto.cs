using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Dtos;

public class UploadFileCreateDto : UploadFileDto, IRequest<SingleResultDto<EntityDto>>
{
}