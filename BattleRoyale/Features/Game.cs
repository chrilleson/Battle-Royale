using BattleRoyale.Entities;
using BattleRoyale.GameElements;

namespace BattleRoyale.Features;

public class Game : IFeature
{
    private readonly GameSetup _gameSetup;

    public Game(GameSetup gameSetup)
    {
        _gameSetup = gameSetup;
    }

    public async Task Run()
    {
        _gameSetup.InsertPlayers();
        _gameSetup.InsertRounds();
        InitializeGame();
    }

    private void InitializeGame()
    {
        Weapons.AssignWeapons(_gameSetup.Players);
    }
}