string[] input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();
int fuel = int.Parse(Console.ReadLine());
int ammunition = int.Parse(Console.ReadLine());

for (int i = 0; i < input.Length; i++)
{
    string[] inputCurrentArr = input[i].Split().ToArray();

    if (inputCurrentArr[0] == "Travel") // Travel {light-years}
    {
        int distance = int.Parse(inputCurrentArr[1]);
        fuel -= distance;

        if (fuel < 0)
        {
            Console.WriteLine("Mission failed.");
            break;
        }
        Console.WriteLine($"The spaceship travelled {distance} light-years.");
    }
    else if (inputCurrentArr[0] == "Enemy") // "Enemy {enemy's armour}"
    {
        int armour = int.Parse(inputCurrentArr[1]);
        if (ammunition >= armour) // fight
        {
            ammunition -= armour;
            Console.WriteLine($"An enemy with {armour} armour is defeated.");
        }
        else if (ammunition < armour) // not enough ammo, run
        {
            if (fuel >= armour * 2)
            {
                fuel -= armour * 2;
                Console.WriteLine($"An enemy with {armour} armour is outmaneuvered.");
            }
            else // fight nor run is possible
            {
                Console.WriteLine("Mission failed.");
                break;
            }
        }
    }
    else if (inputCurrentArr[0] == "Repair") // Repair {number of ammunition and fuel added}"
    {
        int addAmmo = int.Parse(inputCurrentArr[1]);
        int addFuel = int.Parse(inputCurrentArr[1]);
        fuel += addFuel;
        ammunition += addAmmo * 2;
        Console.WriteLine($"Ammunitions added: {addAmmo * 2}.");
        Console.WriteLine($"Fuel added: {addFuel}.");
    }
    else if (inputCurrentArr[0] == "Titan") // "Titan"
    {
        Console.WriteLine("You have reached Titan, all passengers are safe.");
        return;
    }
}