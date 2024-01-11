string message = Console.ReadLine();
string command = string.Empty;
while ((command = Console.ReadLine()) != "Decode")
{
    string[] commandArray = command.Split("|");
	if (commandArray[0] == "Move") // 	"Move {number of letters}":
    {
        // Moves the first n letters to the back of the string
        int lettersCount = int.Parse(commandArray[1]);
        string partOfMessage = message.Substring(0, lettersCount);
        message = message.Remove(0, lettersCount);
        message += partOfMessage;
       
    }
    else if (commandArray[0] == "Insert") // "Insert {index} {value}":
    {
        // Inserts the given value before the given index in the string
        int index = int.Parse(commandArray[1]);
        string value = commandArray[2];
        message = message.Insert(index, value);
    }
    else if (commandArray[0] == "ChangeAll") // ChangeAll {substring} {replacement}":
    {
        // Changes all occurrences of the given substring with the replacement text
        string substring = commandArray[1];
        string replacement = commandArray[2];
        if (message.Contains(substring))
        {
            message = message.Replace(substring, replacement);
        }
    }
}
Console.WriteLine($"The decrypted message is: {message}");
