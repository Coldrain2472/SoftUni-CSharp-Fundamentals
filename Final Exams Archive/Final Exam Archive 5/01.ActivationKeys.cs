using System.Text;

StringBuilder key = new StringBuilder(Console.ReadLine());
string command = string.Empty;
while ((command = Console.ReadLine()) != "Generate")
{
    string[] commandArr = command.Split(">>>");
	if (commandArr[0] == "Contains") // •	"Contains>>>{substring}":
    {
		string substring = commandArr[1];
		// o	If the raw activation key contains the given substring, prints: "{raw activation key} contains {substring}".
		// Otherwise, prints: "Substring not found!"
		if (key.ToString().Contains(substring))
		{
            Console.WriteLine($"{key} contains {substring}");
        }
		else
		{
            Console.WriteLine("Substring not found!");
        }

    }
    else if (commandArr[0] == "Flip") // •	"Flip>>>Upper/Lower>>>{startIndex}>>>{endIndex}":
    {
		string lettersCase = commandArr[1];
		int startIndex = int.Parse(commandArr[2]);
		int endIndex = int.Parse(commandArr[3]);
        // Changes the substring between the given indices (the end index is exclusive)
		// to upper or lower case and then prints the activation key.
		StringBuilder changedKey = new StringBuilder();
        if (lettersCase == "Upper")
		{
			string substring = string.Empty;
			substring = key.ToString().Substring(startIndex, endIndex - startIndex).ToUpper();
			key = key.Remove(startIndex, endIndex - startIndex);
			key = key.Insert(startIndex, substring);
		}
		else // Lower
		{
            string substring = string.Empty;
            substring = key.ToString().Substring(startIndex, endIndex - startIndex).ToLower();
            key = key.Remove(startIndex, endIndex - startIndex);
            key = key.Insert(startIndex, substring);
        }
		Console.WriteLine(key);
	}
	else if (commandArr[0] == "Slice") // •	"Slice>>>{startIndex}>>>{endIndex}":
    {
		int startIndex = int.Parse(commandArr[1]);
		int endIndex = int.Parse(commandArr[2]);
		// deletes the characters between the start and end indices (the end index is exclusive)
		// and prints the activation key.
		key = key.Remove(startIndex, endIndex - startIndex);
        Console.WriteLine(key);
    }
}
Console.WriteLine($"Your activation key is: {key}");
