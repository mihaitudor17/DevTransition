using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests.Utils;

public class UtilsTests
{
    [Fact]
    public void ParseNumbers_ReturnsCorrectList()
    {
        var result = NumberUtils.ParseNumbers("1,2,3");
        Assert.Equal(new List<int> {1,2,3}, result);
    }
}