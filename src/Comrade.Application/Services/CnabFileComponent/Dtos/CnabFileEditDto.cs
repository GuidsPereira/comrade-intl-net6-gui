using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Dtos;

public class CnabFileEditDto : CnabFileDto, IRequest<SingleResultDto<EntityDto>>
{
}