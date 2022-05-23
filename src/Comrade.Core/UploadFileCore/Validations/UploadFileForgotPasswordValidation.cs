using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;

namespace Comrade.Core.UploadFileCore.Validations;

public class UploadFileForgotPasswordValidation : IUploadFileForgotPasswordValidation
{
    private readonly IUploadFileEditValidation _uploadFileEditValidation;

    public UploadFileForgotPasswordValidation(IUploadFileEditValidation uploadFileEditValidation)
    {
        _uploadFileEditValidation = uploadFileEditValidation;
    }

    public ISingleResult<Entity> Execute(UploadFile entity, UploadFile? recordExists)
    {
        var uploadFileEditValidationResult =
            _uploadFileEditValidation.Execute(entity, recordExists);
        if (!uploadFileEditValidationResult.Success)
        {
            return uploadFileEditValidationResult;
        }

        return new SingleResult<Entity>(recordExists);
    }
}