using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.CnabFileComponent.Dtos;
using Comrade.Core.CnabFileCore;
using Comrade.Core.CnabFileCore.Commands;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Application.Services.CnabFileComponent.Handlers;

public class
    CnabFileCreateHandler : IRequestHandler<CnabFileCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcCnabFileCreate _createCnabFile;
    private readonly IMapper _mapper;

    public CnabFileCreateHandler(IMapper mapper, IUcCnabFileCreate createCnabFile)
    {
        _mapper = mapper;
        _createCnabFile = createCnabFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(CnabFileCreateDto request,
        CancellationToken cancellationToken)
    {
        var cnabStrings = request.Info;
        var cnabLista = new CnabFileCreateCommand();
        cnabLista.ListaInfo = new List<CnabFile>();

        foreach (var line in cnabStrings)
        {
            var receberFile = new CnabFile();

            receberFile.Tipo = line.Substring(0, 1);
            receberFile.Data = line.Substring(1, 8);
            receberFile.Valor = line.Substring(9, 10);
            receberFile.CPF = line.Substring(19, 11);
            receberFile.Cartao = line.Substring(30, 12);
            receberFile.Hora = line.Substring(42, 6);
            receberFile.DonoLoja = line.Substring(48, 14);
            receberFile.NomeLoja = line.Substring(62, 18);

            cnabLista.ListaInfo.Add(receberFile);
        }


        var result = await _createCnabFile.Execute(cnabLista).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}