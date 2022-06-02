using Comrade.Core.Bases.Interfaces;
using Comrade.Domain.Bases;
using Comrade.Domain.Models;
using MediatR;

namespace Comrade.Core.CnabFileCore.Commands;

public class CnabFileManyDeleteCommand : CnabFileMany, IRequest<ISingleResult<Entity>>
{
}