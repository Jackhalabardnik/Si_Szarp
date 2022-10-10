using System.Globalization;

namespace L2;

public class MyFormatter
{
    public static string FormatUsdPrice(double price)
    {
        var usc = new CultureInfo("en-us");
        return price.ToString("C2", usc);
    }
    
    public static string FormatPlnPrice(double price)
    {
        var usc = new CultureInfo("pl-PL");
        return price.ToString("C2", usc);
    }
}