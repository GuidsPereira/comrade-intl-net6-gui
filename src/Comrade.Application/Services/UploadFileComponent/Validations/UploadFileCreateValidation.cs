﻿using Comrade.Application.Services.SystemUserComponent.Dtos;
using Comrade.Application.Services.UploadFileComponent.Dtos;

namespace Comrade.Application.Services.UploadFileComponent.Validations;

public class UploadFileCreateValidation : UploadFileValidation<UploadFileCreateDto>
{
    public UploadFileCreateValidation()
    {
        ValidateInfo();
        //ValidateEmail();
        //ValidateRegistration();
    }
}