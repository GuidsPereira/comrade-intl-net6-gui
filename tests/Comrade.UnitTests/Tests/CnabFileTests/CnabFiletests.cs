using Xunit;

namespace Comrade.UnitTests.Tests.UploadFileTests;

public class CnabFiletests
{
    [Fact]
    public void UploadFileTestsTest()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (var i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new string(stringChars);
        Console.WriteLine(finalString);
        Console.ReadLine();


        //var texto = "5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ";

        //var tipo = texto.Substring(0, 1);
        //var data = texto.Substring(1, 8);
        //var valor = texto.Substring(9, 10);
        //var cpf = texto.Substring(19, 11);
        //var cartao = texto.Substring(30, 12);
        //var hora = texto.Substring(42, 6);
        //var dono = texto.Substring(48, 14);
        //var nome = texto.Substring(62, 18);

        //Assert.Equal("5", tipo);
        //Assert.Equal("20190301", data);
        //Assert.Equal("0000013200", valor);
        //Assert.Equal("55641815063", cpf);
        //Assert.Equal("3123****7687", cartao);
        //Assert.Equal("145607", hora);
        //Assert.Equal("MARIA JOSEFINA", dono);
        //Assert.Equal("LOJA DO Ó - MATRIZ", nome);
    }
}