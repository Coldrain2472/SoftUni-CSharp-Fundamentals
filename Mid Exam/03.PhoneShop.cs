// input
using System.Linq;
using System.Numerics;

List<string> phones = Console.ReadLine().Split(", ").ToList();
string command = Console.ReadLine();

// logic
while (command != "End")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    if (input[0] == "Add") // Add - {phone}
    {
        string phone = input[2];
        if (!phones.Contains(phone))
        {
            phones.Add(phone);
        }
    }
    else if (input[0] == "Remove") // Remove - {phone}
    {
        string phone = input[2];
        if (phones.Contains(phone))
        {
            phones.Remove(phone);
        }
    }
    else if (input[0] == "Bonus") // Bonus phone - {oldPhone}:{newPhone}
    {
        string[] wholePhoneString = input[3].Split(':').ToArray();
        string oldPhone = wholePhoneString[0];
        string newPhone = wholePhoneString[1];
        if (phones.Contains(oldPhone))
        {
            int index = phones.IndexOf(oldPhone);
            phones.Insert(index+1, newPhone);
        }
    }
    else if (input[0] == "Last") // Last - {phone}
    {
        string phone = input[2];
        if (phones.Contains(phone))
        {
            int index = phones.IndexOf(phone);
            phones.RemoveAt(index);
            phones.Add(phone);
        }
    }
    command = Console.ReadLine();
}
// output
Console.WriteLine(string.Join(", ", phones));