using L2;

namespace Test_for_L2;

public class TestsForL2
{
    [Fact]
    public void
        FormatUsdPrice_ProperFormat_ShouldReturnProperString()
    {
        var data = 0.05;
        var result = MyFormatter.FormatUsdPrice(data);
        Assert.StartsWith("$", result);
        Assert.Contains(".", result);
    }
    
    [Fact]
    public void
        FormatPlnPrice_ProperFormat_ShouldReturnProperString()
    {
        var data = 0.05;
        var result = MyFormatter.FormatPlnPrice(data);
        Assert.EndsWith("zł", result);
        Assert.Contains(",", result);
    }
}