namespace L2;

public class Fruit
{
    public Fruit()
    {
        Price = -1;
        IsSweet = false;
        Name = "null";
    }

    public static Fruit Create()
    {
        Random r = new Random();
        string[] names = new string[]
        {
            "Apple", "Banana",
            "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit"
        };
        return new Fruit
        {
            Name = names[r.Next(names.Length)],
            IsSweet = r.NextDouble() > 0.5,
            Price = r.NextDouble() * 10
        };
    }

    public override string ToString()
    {
        return
            $"{Name}, {(IsSweet ? "" : "nie")} jest słodki, " +
            $"kosztuje {MyFormatter.FormatPlnPrice(Price)}, czyli {MyFormatter.FormatUsdPrice(UsdPrice)}";
    }

    public double Price { get; set; }

    public bool IsSweet { get; set; }

    public string Name { get; set; }

    public double UsdPrice => Price / UsdCourse.Current;
}