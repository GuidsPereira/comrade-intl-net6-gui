using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Dtos;

public class UploadFileEditDto : UploadFileDto, IRequest<SingleResultDto<EntityDto>>
{
}