using BattleRoyale.Features;
using Microsoft.Extensions.DependencyInjection;

namespace BattleRoyale;

public class Application
{
    private readonly IServiceProvider _serviceProvider;

    private static readonly IReadOnlyDictionary<int, MenuItem> MenuItems = new Dictionary<int, MenuItem>
    {
        { 1, new MenuItem("Play", typeof(Game)) },
        { 2, new MenuItem("Leaderboard", typeof(Leaderboard)) },
    };

    public Application(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Run()
    {
        Console.WriteLine("Welcome to Battle Royale!⚔️\n");
        MenuItems.ToList().ForEach(menuItem => Console.WriteLine($"[{menuItem.Key}] {menuItem.Value.Title}"));
        Console.WriteLine($"[{MenuItems.Count + 1}] Exit");
        Console.Write("> ");

        try
        {
            var key = int.Parse(Console.ReadLine());

            if (key == MenuItems.Count + 1)
            {
                Console.WriteLine("\nHej då👋\n");
                Environment.Exit(0);
                return;
            }

            Console.Clear();
            var selectedMenuItem = MenuItems[key];
            var feature = _serviceProvider.GetRequiredService(selectedMenuItem.Type) as IFeature;

            await feature.Run();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"\n❌ {ex.Message}");
            await Run();
        }
    }

    private record MenuItem(string Title, Type Type);
}