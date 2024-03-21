using System;

string destinations = Console.ReadLine();
string command = string.Empty;
while ((command = Console.ReadLine()) != "Travel")
{
    string[] commandArr = command.Split(":");
    if (command.Contains("Add Stop")) // Add Stop:{index}:{string}":
    {
        int index = int.Parse(commandArr[1]);
        string stop = commandArr[2];
        // Insert the given string at that index only if the index is valid.

        if (index >= 0 && index < destinations.Length)
        {
            destinations = destinations.Insert(index, stop);
        }
        Console.WriteLine(destinations);
    }
    else if (command.Contains("Remove Stop")) // "Remove Stop:{start_index}:{end_index}":                                   
    {
        // Remove the elements of the string from the starting index to the end index (inclusive)
        // if both indices are valid.
        int startIndex = int.Parse(commandArr[1]);
        int endIndex = int.Parse(commandArr[2]);

        if (startIndex >= 0 && startIndex < destinations.Length && endIndex < destinations.Length && endIndex >= 0)
        {
            destinations = destinations.Remove(startIndex, endIndex - startIndex + 1);
        }
        Console.WriteLine(destinations);
    }
    else if (command.Contains("Switch")) // Switch:{old_string}:{new_string}":
    {
        // If the old string is in the initial string, replace it with the new one (all occurrences)
        string oldString = commandArr[1];
        string newString = commandArr[2];
        if (destinations.Contains(oldString))
        {
            destinations = destinations.Replace(oldString, newString);

        }
        Console.WriteLine(destinations);
    }
}
Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");
