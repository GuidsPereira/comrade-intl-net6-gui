using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.CnabFileCore.Validations;

public class CnabFileForgotPasswordValidation : ICnabFileForgotPasswordValidation
{
    private readonly ICnabFileEditValidation _cnabFileEditValidation;

    public CnabFileForgotPasswordValidation(ICnabFileEditValidation cnabFileEditValidation)
    {
        _cnabFileEditValidation = cnabFileEditValidation;
    }

    public ISingleResult<Entity> Execute(CnabFile entity, CnabFile? recordExists)
    {
        var cnabFileEditValidationResult =
            _cnabFileEditValidation.Execute(entity, recordExists);
        if (!cnabFileEditValidationResult.Success)
        {
            return cnabFileEditValidationResult;
        }

        return new SingleResult<Entity>(recordExists);
    }
}