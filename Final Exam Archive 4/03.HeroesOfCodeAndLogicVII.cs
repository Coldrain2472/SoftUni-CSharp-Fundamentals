int heroesCount = int.Parse(Console.ReadLine());

Dictionary<string, int> heroAndHp = new Dictionary<string, int>();
Dictionary<string, int> heroAndMp = new Dictionary<string, int>();

for (int i = 0; i < heroesCount; i++)
{
    // "{hero name} {HP} {MP}"
    string[] heroInfo = Console.ReadLine().Split();
    string heroName = heroInfo[0];
    int hp = int.Parse(heroInfo[1]);
    int mp = int.Parse(heroInfo[2]);
    // -	a hero can have a maximum of 100 HP and 200 MP
    if (hp > 100)
    {
        hp = 100;
    }
    if (mp > 200)
    {
        mp = 200;
    }
    heroAndHp.Add(heroName, hp);
    heroAndMp.Add(heroName, mp);
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "End")
{
    string[] commandArr = command.Split(" - ");
    string commandInfo = commandArr[0];

    if (commandInfo == "CastSpell") // "CastSpell – {hero name} – {MP needed} – {spell name}"
    {
        string hero = commandArr[1];
        int mpNeeded = int.Parse(commandArr[2]);
        string spell = commandArr[3];
        if (heroAndMp[hero] >= mpNeeded)
        {
            heroAndMp[hero] -= mpNeeded;
            Console.WriteLine($"{hero} has successfully cast {spell} and now has {heroAndMp[hero]} MP!");
        }
        else
        {
            Console.WriteLine($"{hero} does not have enough MP to cast {spell}!");
        }
    }
    else if (commandInfo == "TakeDamage") // TakeDamage – {hero name} – {damage} – {attacker}"
    {
        string hero = commandArr[1];
        int damage = int.Parse(commandArr[2]);
        string attacker = commandArr[3];
        heroAndHp[hero] -= damage;
        if (heroAndHp[hero] > 0)
        {
            Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {heroAndHp[hero]} HP left!");
        }
        else
        {
            Console.WriteLine($"{hero} has been killed by {attacker}!");
            heroAndHp.Remove(hero);
            heroAndMp.Remove(hero);
        }
    }
    else if (commandInfo == "Recharge") // "Recharge – {hero name} – {amount}"
    {
        string hero = commandArr[1];
        int amount = int.Parse(commandArr[2]);
        int previousMp = heroAndMp[hero];
        heroAndMp[hero] += amount;

        if (heroAndMp[hero] > 200)
        {
            heroAndMp[hero] = 200;
            Console.WriteLine($"{hero} recharged for {200 - previousMp} MP!");
        }
        else
        {
            Console.WriteLine($"{hero} recharged for {amount} MP!");
        }
    }
    else if (commandInfo == "Heal") // "Heal – {hero name} – {amount}"
    {
        string hero = commandArr[1];
        int amount = int.Parse(commandArr[2]);
        int previousHp = heroAndHp[hero];
        heroAndHp[hero] += amount;
        if (heroAndHp[hero] > 100)
        {
            heroAndHp[hero] = 100;
            Console.WriteLine($"{hero} healed for {100 - previousHp} HP!");
        }
        else
        {
            Console.WriteLine($"{hero} healed for {amount} HP!");
        }
    }
}
// Print all members of your party who are still alive, in the following format (their HP/MP need to be indented 2 spaces):
//{hero name}
//  HP: { current HP}
//MP: { current MP}

foreach (var hero in heroAndHp)
{
    Console.WriteLine($"{hero.Key}");
    Console.WriteLine($"  HP: {hero.Value}");
    Console.WriteLine($"  MP: {heroAndMp[hero.Key]}");
}
