using Comrade.Application.Bases;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Dtos;

public class CnabFileManyCreateDto : CnabFileManyDto, IRequest<SingleResultDto<EntityDto>>
{
}