using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.CnabFileCore.Validations;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileManyCore.Validations;

public class CnabFileManyForgotPasswordValidation : ICnabFileManyForgotPasswordValidation
{
    private readonly ICnabFileManyEditValidation _cnabFileManyEditValidation;

    public CnabFileManyForgotPasswordValidation(ICnabFileManyEditValidation cnabFileEditValidation)
    {
        _cnabFileManyEditValidation = cnabFileEditValidation;
    }

    public ISingleResult<Entity> Execute(CnabFileMany entity, CnabFileMany? recordExists)
    {
        var cnabFileEditValidationResult =
            _cnabFileManyEditValidation.Execute(entity, recordExists);
        if (!cnabFileEditValidationResult.Success)
        {
            return cnabFileEditValidationResult;
        }

        return new SingleResult<Entity>(recordExists);
    }
}