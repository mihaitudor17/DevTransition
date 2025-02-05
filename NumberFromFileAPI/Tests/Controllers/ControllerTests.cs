using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Tests.Controllers;

public class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetNumbers_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/numbers");
        response.EnsureSuccessStatusCode(); 
    }
}