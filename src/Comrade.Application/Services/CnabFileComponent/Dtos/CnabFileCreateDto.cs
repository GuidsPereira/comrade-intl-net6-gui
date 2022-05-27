using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Dtos;

public class CnabFileCreateDto : CnabFileDto, IRequest<SingleResultDto<EntityDto>>
{
}