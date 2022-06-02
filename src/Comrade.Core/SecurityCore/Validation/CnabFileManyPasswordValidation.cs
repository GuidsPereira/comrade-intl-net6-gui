using Comrade.Core.Bases.Interfaces;
using Comrade.Core.Bases.Results;
using Comrade.Core.CnabFileCore;
using Comrade.Domain.Extensions;
using Comrade.Domain.Models;

namespace Comrade.Core.SecurityCore.Validation;

public class CnabFileManyPasswordValidation : ICnabFileManyPasswordValidation
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly ICnabFileManyRepository _cnabFileManyRepository;

    public CnabFileManyPasswordValidation(ICnabFileManyRepository cnabFileManyRepository,
        IPasswordHasher passwordHasher)
    {
        _cnabFileManyRepository = cnabFileManyRepository;
        _passwordHasher = passwordHasher;
    }

    public ISingleResult<CnabFileMany> Execute(Guid key, string password)
    {
        var usuSession = _cnabFileManyRepository.GetById(key).Result;
        var keyValidation = usuSession != null;

        if (keyValidation)
        {
            var (verified, needsUpgrade) = _passwordHasher.Check(usuSession!.Password, password);

            if (!verified)
            {
                return new SingleResult<CnabFileMany>(1001,
                    "Usuário ou password informados não são válidos");
            }

            if (needsUpgrade)
            {
                return new SingleResult<CnabFileMany>(1009,
                    "Senha precisa ser atualizada");
            }


            return new SingleResult<CnabFileMany>(usuSession);
        }


        return new SingleResult<CnabFileMany>(1001,
            "Usuário ou password informados não são válidos");
    }
}