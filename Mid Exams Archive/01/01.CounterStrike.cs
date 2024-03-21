// input
int energy = int.Parse(Console.ReadLine());
string command = Console.ReadLine();
int battlesWon = 0;
bool hasEnoughEnergy = true;
// logic
while (command != "End of battle")
{
    int distance = int.Parse(command);
    if (energy - distance < 0)
    {
        hasEnoughEnergy = false;
        break;
    }

    energy -= distance;
    battlesWon++;
    if (battlesWon % 3 == 0)
    {
        energy += battlesWon;
    }

    command = Console.ReadLine();
}


// output
if (hasEnoughEnergy)
{
    Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
}
else
{
    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
}