using Comrade.Application.Bases;

namespace Comrade.Application.Services.UploadFileComponent.Dtos;

public class UploadFileDto : EntityDto
{
    public string?[] Info { get; set; }
    public string? Tipo { get; set; }
    public string? Data { get; set; }
    public string? Valor { get; set; }
    public string? CPF { get; set; }
    public string? Cartao { get; set; }
    public string? Hora { get; set; }
    public string? DonoLoja { get; set; }
    public string? NomeLoja { get; set; }
}