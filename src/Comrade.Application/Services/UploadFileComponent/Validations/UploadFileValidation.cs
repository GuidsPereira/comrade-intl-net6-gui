using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.UploadFileComponent.Validations;

public class UploadFileValidation<TDto> : DtoValidation<TDto>
    where TDto : UploadFileDto
{
}