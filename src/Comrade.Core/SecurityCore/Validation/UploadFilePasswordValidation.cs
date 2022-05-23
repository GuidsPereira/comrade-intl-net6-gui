using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.UploadFileCore;
using Comrade.Domain.Extensions;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public class UploadFilePasswordValidation : IUploadFilePasswordValidation
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUploadFileRepository _uploadFileRepository;

    public UploadFilePasswordValidation(IUploadFileRepository uploadFileRepository,
        IPasswordHasher passwordHasher)
    {
        _uploadFileRepository = uploadFileRepository;
        _passwordHasher = passwordHasher;
    }

    public ISingleResult<UploadFile> Execute(Guid key, string password)
    {
        var usuSession = _uploadFileRepository.GetById(key).Result;
        var keyValidation = usuSession != null;

        if (keyValidation)
        {
            var (verified, needsUpgrade) = _passwordHasher.Check(usuSession!.Password, password);

            if (!verified)
            {
                return new SingleResult<UploadFile>(1001,
                    "Usuário ou password informados não são válidos");
            }

            if (needsUpgrade)
            {
                return new SingleResult<UploadFile>(1009,
                    "Senha precisa ser atualizada");
            }


            return new SingleResult<UploadFile>(usuSession);
        }


        return new SingleResult<UploadFile>(1001,
            "Usuário ou password informados não são válidos");
    }
}