using System.Net;
using System.Net.Http.Json;
using MinimalApiVeiculos.Models;
using Xunit;

public class VeiculoApiTests
{
    [Fact]
    public async Task CadastroVeiculo_DeveRetornarCreated()
    {
        var factory = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        // Autentica
        var login = new Admin { Username = "admin", Password = "123456" };
        var loginResp = await client.PostAsJsonAsync("/login", login);
        Assert.Equal(HttpStatusCode.OK, loginResp.StatusCode);
        var token = (await loginResp.Content.ReadFromJsonAsync<Dictionary<string, string>>())["token"];
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        // Testa cadastro
        var veiculo = new Veiculo { Marca = "Fiat", Modelo = "Uno", Placa = "ABC1234", Ano = 2020 };
        var resp = await client.PostAsJsonAsync("/veiculos", veiculo);
        Assert.Equal(HttpStatusCode.Created, resp.StatusCode);
    }
}