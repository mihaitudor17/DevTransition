using Microsoft.Extensions.Configuration;
using Xunit;
using Assert = Xunit.Assert;


namespace Tests.Configs;

public class ConfigurationTests
{
    [Fact]
    public void Configuration_LoadsExpectedValues()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("Resources/appSettings.json")
            .Build();

        var expectedValue = "Data Source=NumbersFromString.db;"; 
        var actualValue = config["DefaultConnection"];

        Assert.Equal(expectedValue, actualValue);
    }
}