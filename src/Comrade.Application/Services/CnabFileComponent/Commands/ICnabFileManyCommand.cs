using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.cnabFileComponent.Commands;

public interface ICnabFileManyCommand
{
    Task<ISingleResultDto<EntityDto>> Create(CnabFileManyCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(CnabFileManyEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}