using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.CnabFileCore;
using Comrade.Domain.Extensions;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public class CnabFilePasswordValidation : ICnabFilePasswordValidation
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICnabFileRepository _cnabFileRepository;

    public CnabFilePasswordValidation(ICnabFileRepository cnabFileRepository,
        IPasswordHasher passwordHasher)
    {
        _cnabFileRepository = cnabFileRepository;
        _passwordHasher = passwordHasher;
    }

    public ISingleResult<CnabFile> Execute(Guid key, string password)
    {
        var usuSession = _cnabFileRepository.GetById(key).Result;
        var keyValidation = usuSession != null;

        if (keyValidation)
        {
            var (verified, needsUpgrade) = _passwordHasher.Check(usuSession!.Password, password);

            if (!verified)
            {
                return new SingleResult<CnabFile>(1001,
                    "Usuário ou password informados não são válidos");
            }

            if (needsUpgrade)
            {
                return new SingleResult<CnabFile>(1009,
                    "Senha precisa ser atualizada");
            }


            return new SingleResult<CnabFile>(usuSession);
        }


        return new SingleResult<CnabFile>(1001,
            "Usuário ou password informados não são válidos");
    }
}