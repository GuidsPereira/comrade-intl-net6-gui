using Xunit;

namespace Comrade.UnitTests.Tests.UploadFileTests;

public class UploadFileTests
{
    [Fact]
    public void UploadFileTestsTest()
    {
        string? texto = "5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ";

        string tipo = texto.Substring(0, 1);
        string? data = texto.Substring(1, 8);
        string? valor = texto.Substring(9, 10);
        string? cpf = texto.Substring(19, 11);
        string? cartao = texto.Substring(30, 12);
        string? hora = texto.Substring(42, 6);
        string? dono = texto.Substring(48, 14);
        string? nome = texto.Substring(62, 18);

        Assert.Equal("5", tipo);
        Assert.Equal("20190301", data);
        Assert.Equal("0000013200", valor);
        Assert.Equal("55641815063", cpf);
        Assert.Equal("3123****7687", cartao);
        Assert.Equal("145607", hora);
        Assert.Equal("MARIA JOSEFINA", dono);
        Assert.Equal("LOJA DO Ó - MATRIZ", nome);       
    }
}

/*
Tipo
1-1

Data
2-9

Valor
10-19
(Valor da movimentação. Obs. O valor encontrado no arquivo precisa ser divido por cem(valor / 100.00) para normalizá-lo.)

CPF
20-30

Cartão
31-42

Hora
43-48

Dono da loja
49-62

Nome loja 
63-81
 */