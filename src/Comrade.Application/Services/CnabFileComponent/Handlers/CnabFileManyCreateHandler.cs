using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Handlers;

public class
    CnabFileManyCreateHandler : IRequestHandler<CnabFileManyCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcCnabFileManyCreate _createCnabFileMany;
    private readonly IMapper _mapper;

    public CnabFileManyCreateHandler(IMapper mapper, IUcCnabFileManyCreate createCnabFileMany)
    {
        _mapper = mapper;
        _createCnabFileMany = createCnabFileMany;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(CnabFileManyCreateDto request,
        CancellationToken cancellationToken)
    {
        var cnabStrings = request.InfoMany;
        var cnabLista = new CnabFileManyCreateCommand();
        cnabLista.InfoLista = new List<CnabFileMany>();

        foreach (var line in cnabStrings)
        {
            var receberFileMany = new CnabFileMany();

            receberFileMany.Tipo = line.Substring(0, 1);
            receberFileMany.Data = line.Substring(1, 8);
            receberFileMany.Valor = line.Substring(9, 10);
            receberFileMany.CPF = line.Substring(19, 11);
            receberFileMany.Cartao = line.Substring(30, 12);
            receberFileMany.Hora = line.Substring(42, 6);
            receberFileMany.DonoLoja = line.Substring(48, 14);
            receberFileMany.NomeLoja = line.Substring(62, 18);

            cnabLista.InfoLista.Add(receberFileMany);
        }


        var result = await _createCnabFileMany.Execute(cnabLista).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}