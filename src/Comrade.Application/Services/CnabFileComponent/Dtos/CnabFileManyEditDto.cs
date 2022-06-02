using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Dtos;

public class CnabFileManyEditDto : CnabFileManyDto, IRequest<SingleResultDto<EntityDto>>
{
}