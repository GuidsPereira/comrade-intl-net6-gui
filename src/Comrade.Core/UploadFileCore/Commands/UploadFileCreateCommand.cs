using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.UploadFileCore.Commands;

public class UploadFileCreateCommand : UploadFile, IRequest<ISingleResult<Entity>>
{
    public List<UploadFile> ListaInfo { get; set; }
}