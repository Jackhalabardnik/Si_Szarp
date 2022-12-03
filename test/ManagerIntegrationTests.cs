using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace test;

public class ManagerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;

    public ManagerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(
            new WebApplicationFactoryClientOptions { AllowAutoRedirect = false }
        );
    }

    [Fact]
    public async void Get_WhenEmpty_ReturnEmptyList()
    {
        var act = await _client.GetAsync("/api/Blacklist");

        Assert.True(act.IsSuccessStatusCode);
        var json = JsonSerializer.Deserialize<string[]>(await act.Content.ReadAsStringAsync());

        Assert.Empty(json);
    }
    
    [Fact]
    public async void Get_WhenNotEmpty_ReturnNotEmptyList()
    {
        var stringContent = new StringContent("");
        var act_post = await _client.PostAsync("/api/Blacklist?word=boi", stringContent);
        var act_get = await _client.GetAsync("/api/Blacklist");

        Assert.True(act_post.IsSuccessStatusCode);
        Assert.True(act_get.IsSuccessStatusCode);
        var json = JsonSerializer.Deserialize<string[]>(await act_get.Content.ReadAsStringAsync());

        Assert.NotEmpty(json);
    }
}