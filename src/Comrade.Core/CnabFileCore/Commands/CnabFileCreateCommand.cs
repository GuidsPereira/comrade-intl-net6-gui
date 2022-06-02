using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.CnabFileCore.Commands;

public class CnabFileCreateCommand : CnabFile, IRequest<ISingleResult<Entity>>
{
    public List<CnabFile> InfoLista { get; set; }
}