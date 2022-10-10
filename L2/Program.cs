using L2;

UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();

var fruitList = new List<Fruit>();

for (var i = 0; i < 15; i++)
{
    fruitList.Add(Fruit.Create());
}

fruitList = fruitList.Where(x => x.IsSweet).OrderByDescending(x => x.Price).ToList();

foreach (var fruit in fruitList)
{
    Console.WriteLine(fruit);
}

Console.WriteLine(UsdCourse.Current);