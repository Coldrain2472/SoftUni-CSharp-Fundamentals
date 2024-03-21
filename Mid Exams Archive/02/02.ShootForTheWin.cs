List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

string index = Console.ReadLine();
int count = 0;

while (index != "End")
{
    int newIndex = int.Parse(index);

    if (newIndex < 0 || newIndex >= targets.Count || targets[newIndex] == -1)
    {
        index = Console.ReadLine();
        continue;
    }

    int oldValue = targets[newIndex];

    targets[newIndex] = -1;
    count++;
    for (int i = 0; i <= targets.Count - 1; i++)
    {
        if (targets[i] == -1)
        {
            continue;
        }

        if (oldValue < targets[i])
        {

            int newValue = targets[i] - oldValue;
            targets[i] = newValue;
        }
        else if (oldValue >= targets[i] && targets[i] != -1)
        {
            int newValue = oldValue + targets[i];
            targets[i] = newValue;
        }

    }
    index = Console.ReadLine();
}

Console.Write($"Shot targets: {count} -> {string.Join(" ", targets)}");
