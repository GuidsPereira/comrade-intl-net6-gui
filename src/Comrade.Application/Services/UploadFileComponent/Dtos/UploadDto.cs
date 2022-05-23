using Comrade.Application.Bases;

namespace Comrade.Application.Services.UploadFileComponent.Dtos;

public class UploadFileDto : EntityDto
{
    public string? Info { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Registration { get; set; }
    public DateTime? RegisterDate { get; set; }
}

  