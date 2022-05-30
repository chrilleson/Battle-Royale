namespace BattleRoyale.Entities;

public record Weapon(string Name, string Icon, double PickUpRate, int? BaseDamage, int CriticalHitModifier);

public class Weapons
{
    private static readonly IReadOnlyDictionary<int, Weapon> _weapons = new Dictionary<int, Weapon>
    {
        { 0, new("Eldboll", "🔥", 0.5, 10, 5) },
        { 1, new("Kokosnöt", "🥥", 0.5, 10, 5) },
        { 2, new("Regnbågsvätska", "🌈", 0.5, 10, 5) },
        { 3, new("Fisk", "🐟", 0.5, 10, 5) },
        { 4, new("Rentgift", "🧪", 0.5, 10, 5) },
        { 5, new("Majskolv", "🌽", 0.5, 10, 5) },
        { 6, new("Nät", "🕸", 0.5, 10, 5) },
        { 7, new("Ägg", "🥚", 0.5, 10, 5) },
        { 8, new("Tårtbit", "🍰", 0.5, 10, 5) },
        { 9, new("Väckarklocka", "⏰", 0.5, 10, 5) },
        { 10, new("Amerikanskfotboll", "🏈", 0.5, 10, 5) },
        { 11, new("Vattenpistol", "🔫", 0.5, 10, 5) },
        { 12, new("DNA", "🧬", 0.5, 10, 5) },
        { 13, new("Kvast", "🧹", 0.5, 10, 5) },
        { 14, new("Balans", "☯", 0.5, 10, 5) },
        { 15, new("Sömn", "💤", 0.5, 10, 5) },
        { 16, new("Munk", "🍩", 0.5, 10, 5) },
        { 17, new("Våg", "🌊", 0.5, 10, 5) },
        { 18, new("Diamant", "💎", 0.5, 10, 5) },
        { 19, new("Ljud", "🔊", 0.5, 10, 5) },
        { 20, new("Email", "📧", 0.5, 10, 5) },
        { 21, new("Magnet", "🧲", 0.5, 10, 5) }
    };

    public static Weapon GetWeapon(int key) => _weapons[key];

    public static void AssignWeapons(List<Player> players)
    {
        foreach (var player in players)
        {
            player.Weapon = GetWeapon(new Random().Next(0, _weapons.Count));
        }
    }
}