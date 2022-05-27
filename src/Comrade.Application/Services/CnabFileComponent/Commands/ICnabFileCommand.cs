using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.CnabFileComponent.Dtos;

namespace Comrade.Application.Services.cnabFileComponent.Commands;

public interface ICnabFileCommand
{
    Task<ISingleResultDto<EntityDto>> Create(CnabFileCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(CnabFileEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}