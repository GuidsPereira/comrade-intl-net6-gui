﻿using Comrade.Application.Services.AirplaneServices.Dtos;

namespace Comrade.Application.Services.AirplaneServices.Validations;

public class AirplaneEditValidation : AirplaneValidation<AirplaneEditDto>
{
    public AirplaneEditValidation()
    {
        ValidateCode();
        ValidateModel();
        ValidatePassengerQuantity();
    }
}