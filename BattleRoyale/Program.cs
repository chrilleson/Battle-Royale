using System.Text;
using BattleRoyale;
using BattleRoyale.Features;
using BattleRoyale.GameElements;
using Microsoft.Extensions.DependencyInjection;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

var services = ConfigureServices();
var serviceProvider = services.BuildServiceProvider();
var application = serviceProvider.GetRequiredService<Application>();

await application.Run();

static IServiceCollection ConfigureServices() =>
    new ServiceCollection()
        .AddSingleton<GameSetup>()
        .AddSingleton<Game>()
        .AddSingleton<Leaderboard>()
        .AddSingleton<Application>();