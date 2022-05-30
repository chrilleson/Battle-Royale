namespace BattleRoyale.Entities;

public class Player
{
    private string Name { get; set; }
    public int Health { get; set; }
    public Weapon? Weapon { get; set; }
    public int CriticalHitChance{ get; set; }

    public Player(string name, int health, Weapon? weapon, int criticalHitChance)
    {
        Name = name;
        Health = health;
        Weapon = weapon;
        CriticalHitChance = criticalHitChance;
    }
}