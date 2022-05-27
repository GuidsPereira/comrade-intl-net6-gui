using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.CnabFileComponent.Validations;

public class CnabFileValidation<TDto> : DtoValidation<TDto>
    where TDto : CnabFileDto
{
}