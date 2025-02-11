﻿using Comrade.Application.Services.SystemUserServices.Dtos;

namespace Comrade.Application.Services.SystemUserServices.Validations;

public class SystemUserEditValidation : SystemUserValidation<SystemUserEditDto>
{
    public SystemUserEditValidation()
    {
        ValidateName();
        ValidateEmail();
        PasswordValidation();
        ValidateRegistration();
    }
}