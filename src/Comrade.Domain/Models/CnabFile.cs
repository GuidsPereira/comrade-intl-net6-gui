using Comrade.Domain.Bases;

namespace Comrade.Domain.Models;

[Table("cnabfile_cnab_file")]
public class CnabFile : Entity
{
    public CnabFile()
    {
        Tipo = "";
        Data = "";
        Valor = "";
        CPF = "";
        Cartao = "";
        Hora = "";
        DonoLoja = "";
        NomeLoja = "";
        Password = "";
    }

    [Column("cnabfile_tx_tipo", TypeName = "varchar")]
    [MaxLength(255)]

    public string? Tipo { get; set; } // varchar(255), not null

    [Column("cnabfile_tx_data", TypeName = "varchar")]
    [MaxLength(255)]
    public string? Data { get; set; } // varchar(255), null

    [Column("cnabfile_tx_valor", TypeName = "varchar")]
    [MaxLength(1023)]

    public string? Valor { get; set; } // varchar(1023), not null

    [Column("cnabfile_tx_cpf", TypeName = "varchar")]
    [MaxLength(255)]

    public string? CPF { get; set; } // varchar(255), not null

    [Column("cnabfile_tx_cartao", TypeName = "varchar")]
    [MaxLength(255)]

    public string? Cartao { get; set; } // varchar(255), not null

    [Column("cnabfile_tx_hora", TypeName = "varchar")]
    [MaxLength(255)]

    public string? Hora { get; set; } // varchar(255), not null

    [Column("cnabfile_dono_loja", TypeName = "varchar")]
    [MaxLength(255)]

    public string? DonoLoja { get; set; } // varchar(255), not null

    [Column("cnabfile_nome_loja", TypeName = "varchar")]
    [MaxLength(255)]

    public string? NomeLoja { get; set; } // varchar(255), not null

    public string? Password { get; set; }
}