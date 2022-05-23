using Comrade.Domain.Bases;

namespace Comrade.Domain.Models;

[Table("upfi_upload_file")]
public class UploadFile : Entity
{
    public UploadFile()
    {
        
        Tipo = "";
        Data = "";
        Valor = "";
        CPF = "";
        Cartao = "";
        Hora = "";
        DonoLoja = "";
        NomeLoja = "";
    }

    public UploadFile(string tipo, string data, string valor, string cpf, string cartao,
        string hora, string donoLoja, string nomeLoja )
    {
        Tipo = tipo;
        Data = data;
        Valor = valor;
        CPF = cpf;
        Cartao = cartao;
        Hora = hora;
        DonoLoja = donoLoja;
        NomeLoja = nomeLoja;

    }

    [Column("upfi_tx_tipo", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "NOME USU is required")]
    public string Tipo { get; set; } // varchar(255), not null

    [Column("upfi_tx_data", TypeName = "varchar")]
    [MaxLength(255)]
    public string? Data { get; set; } // varchar(255), null

    [Column("upfi_tx_valor", TypeName = "varchar")]
    [MaxLength(1023)]
    [Required(ErrorMessage = "Password is required")]
    public string Valor { get; set; } // varchar(1023), not null

    [Column("upfi_tx_cpf", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Registration is required")]
    public string CPF { get; set; } // varchar(255), not null

    [Column("upfi_tx_cartao", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Registration is required")]
    public string Cartao { get; set; } // varchar(255), not null

    [Column("upfi_tx_hora", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Registration is required")]
    public string Hora { get; set; } // varchar(255), not null

    [Column("upfi_dono_loja", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Registration is required")]
    public string DonoLoja { get; set; } // varchar(255), not null

    [Column("upfi_nome_loja", TypeName = "varchar")]
    [MaxLength(255)]
    [Required(ErrorMessage = "Registration is required")]
    public string NomeLoja { get; set; } // varchar(255), not null
}