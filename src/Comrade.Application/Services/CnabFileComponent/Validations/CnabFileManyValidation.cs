using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.CnabFileComponent.Validations;

public class CnabFileManyValidation<TDto> : DtoValidation<TDto>
    where TDto : CnabFileManyDto
{
}