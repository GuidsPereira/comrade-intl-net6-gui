using AutoMapper;
using Comrade.Application.Bases;
using Comrade.Application.Services.UploadFileComponent.Dtos;
using Comrade.Core.UploadFileCore;
using Comrade.Core.UploadFileCore.Commands;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Application.Services.UploadFileComponent.Handlers;

public class
    UploadFileCreateHandler : IRequestHandler<UploadFileCreateDto, SingleResultDto<EntityDto>>
{
    private readonly IUcUploadFileCreate _createUploadFile;
    private readonly IMapper _mapper;

    public UploadFileCreateHandler(IMapper mapper, IUcUploadFileCreate createUploadFile)
    {
        _mapper = mapper;
        _createUploadFile = createUploadFile;
    }

    public async Task<SingleResultDto<EntityDto>> Handle(UploadFileCreateDto request,
        CancellationToken cancellationToken)
    {
        var teste = request.Info;
        var testeLista = new UploadFileCreateCommand();
        testeLista.ListaInfo = new List<UploadFile>();

        foreach (var line in teste)
        {
            var receberFile = new UploadFile();

            receberFile.Tipo = line.Substring(0, 1);
            receberFile.Data = line.Substring(1, 8);
            receberFile.Valor = line.Substring(9, 10);
            receberFile.CPF = line.Substring(19, 11);
            receberFile.Cartao = line.Substring(30, 12);
            receberFile.Hora = line.Substring(42, 6);
            receberFile.DonoLoja = line.Substring(48, 14);
            receberFile.NomeLoja = line.Substring(62, 18);

            testeLista.ListaInfo.Add(receberFile);
        }


        var result = await _createUploadFile.Execute(testeLista).ConfigureAwait(false);
        return new SingleResultDto<EntityDto>(result);
    }
}