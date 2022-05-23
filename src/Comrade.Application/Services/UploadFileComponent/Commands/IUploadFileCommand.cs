using Comrade.Application.Bases;
using Comrade.Application.Bases.Interfaces;
using Comrade.Application.Services.UploadFileComponent.Dtos;

namespace Comrade.Application.Services.UploadFileComponent.Commands;

public interface IUploadFileCommand
{
    Task<ISingleResultDto<EntityDto>> Create(UploadFileCreateDto dto);
    Task<ISingleResultDto<EntityDto>> Edit(UploadFileEditDto dto);
    Task<ISingleResultDto<EntityDto>> Delete(Guid id);
}