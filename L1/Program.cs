using System.Text.Json;
using L1;

const string fileName = "highscores.json";

var highScores = File.Exists(fileName)
    ? JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(fileName))
    : new List<HighScore>();
do
{
    var rand = new Random();
    var value = rand.Next(1, 101);
    var score = 0;

    do
    {
        var guess = 0;
        do
        {
            Console.WriteLine("Give me your guess");
            var doBreak = true;
            try
            {
                guess = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("I demand a number");
                doBreak = false;
            }

            if (doBreak) break;
        } while (true);

        if (guess == value) break;
        Console.WriteLine(guess > value ? "Your number is too high" : "Your number is too low");
        score++;
    } while (true);

    Console.WriteLine($"You won after {score} tries\nEnter your name:");
    var name = Console.ReadLine();
    highScores?.Add(new HighScore { Name = name, Trials = score });

    if (highScores != null)
    {
        highScores = highScores.OrderBy(x => x.Trials).ToList();
        foreach (var highScore in highScores)
        {
            Console.WriteLine($"{highScore.Name} --- {highScore.Trials}");
        }
    }

    Console.WriteLine("Do you want to exit? Enter yes to exit, something other to stay");
    var exit = Console.ReadLine();
    if (exit == "yes") break;
} while (true);

File.WriteAllText(fileName, JsonSerializer.Serialize(highScores));

Console.WriteLine("Thank you for the game");