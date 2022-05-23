using Comrade.Application.Bases;
using Comrade.Application.Messages;
using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using FluentValidation;

namespace Comrade.Application.Services.UploadFileComponent.Validations;

public class UploadFileValidation<TDto> : DtoValidation<TDto>
    where TDto : UploadFileDto
{
    protected void ValidateInfo()
    {
        RuleFor(v => v.Info)
            .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
            .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
            .WithName("Info");
    }

    //protected void ValidateEmail()
    //{
    //    RuleFor(v => v.Email)
    //        .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
    //        .WithName("Email");
    //}

    //protected void ValidateRegistration()
    //{
    //    RuleFor(v => v.Registration)
    //        .NotEmpty().WithMessage(ApplicationMessage.CAMPO_OBRIGATORIO)
    //        .MaximumLength(255).WithMessage(ApplicationMessage.TAMANHO_ESPECIFICO_CAMPO)
    //        .WithName("Registration");
    //}
}