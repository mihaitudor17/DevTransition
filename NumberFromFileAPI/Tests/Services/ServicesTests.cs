using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests.Services;

public class ServicesTests
{
    [Fact]
    public void GetDouble_ReturnsDoubleValue()
    {
        var mockRepo = new Mock<INumberRepository>();
        mockRepo.Setup(r => r.GetValue(2)).Returns(2);

        var service = new NumberService(mockRepo.Object);
        var result = service.GetDouble(2);

        Assert.Equal(4, result);
    }
}