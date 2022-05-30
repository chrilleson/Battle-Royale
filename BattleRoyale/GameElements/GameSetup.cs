using System.Globalization;
using BattleRoyale.Entities;

namespace BattleRoyale.GameElements;

public class GameSetup
{
    public List<Player> Players { get; } = new();
    public int? RoundLength { get; set; }


    public void InsertRounds()
    {
        Console.WriteLine("How many rounds do you want to fight?");
        Console.WriteLine("Leave empty if you want to do 'Last man standing'.");
        Console.Write("> ");

        try
        {
            var couldParse = int.TryParse(Console.ReadLine(), out var nrOfRounds);
            RoundLength = couldParse ? nrOfRounds : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            InsertRounds();
        }
    }

    public void InsertPlayers()
    {
        var input = string.Empty;
        var playerNames = new List<string>();

        Console.WriteLine("Enter Player names.");
        Console.WriteLine("Enter all names, seperated by comma or one by one.");
        Console.WriteLine("Press 1 when all player names have been entered.");
        Console.Write("> ");

        while (input is not "1")
        {
            if (playerNames.Any())
            {
                Console.Clear();
                Console.WriteLine("Currently entered players are:");
                playerNames.ForEach(x =>Console.WriteLine(x.TrimStart(' ')));
                Console.WriteLine("\nForgot anyone? If not, enter 1");
                Console.Write("> ");
            }

            input = Console.ReadLine();
            if (input is not "1" or null) playerNames.AddRange(input!.Split(','));
        }

        foreach (var playerName in playerNames)
        {
            var trimStart = playerName.TrimStart(' ');
            Players.Add(new Player(trimStart, 100, null, 0));
        }
    }
}