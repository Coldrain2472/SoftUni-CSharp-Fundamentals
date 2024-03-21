List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
string command = Console.ReadLine();

while (command != "End")
{
    string[] commandArr = command.Split();
    if (commandArr[0] == "Shoot") //	"Shoot {index} {power}"
    {
        int index = int.Parse(commandArr[1]);
        int power = int.Parse(commandArr[2]);
        if (index >= 0 && index < numbers.Count) // target is found and shot
        {
            numbers[index] -= power;
            if (numbers[index] <= 0)
            {
                numbers.RemoveAt(index);
            }
        }
    }
    else if (commandArr[0] == "Add") // "Add {index} {value}"
    {
        int index = int.Parse(commandArr[1]);
        int value = int.Parse(commandArr[2]);
        if (index >= 0 && index < commandArr.Length)
        {
            numbers.Insert(index, value);
        }
        else
        {
            Console.WriteLine("Invalid placement!");
        }

    }
    else if (commandArr[0] == "Strike") // "Strike {index} {radius}"
    {
        int index = int.Parse(commandArr[1]);
        int radius = int.Parse(commandArr[2]);
        if (index - radius >= 0 && index + radius < numbers[numbers.Count - 1])
        {
            numbers.RemoveRange(index - radius, radius * 2 + 1);
        }
        else
        {
            Console.WriteLine("Strike missed!");
        }
    }
    
    command = Console.ReadLine();
}

Console.WriteLine(string.Join('|', numbers));