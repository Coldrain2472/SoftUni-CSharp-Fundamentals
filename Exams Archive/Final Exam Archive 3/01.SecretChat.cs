string concealedMessage = Console.ReadLine();
string command = string.Empty;
while ((command = Console.ReadLine()) != "Reveal") // ":|:"
{
    string[] commandArr = command.Split(":|:");
    if (commandArr[0] == "InsertSpace") // "InsertSpace:|:{index}":
    {
        int index = int.Parse(commandArr[1]);
        //Inserts a single space at the given index
        string space = " ";
        concealedMessage = concealedMessage.Insert(index, space);
        Console.WriteLine(concealedMessage);
    }
    else if (commandArr[0] == "Reverse") // "Reverse:|:{substring}":
    {
        string substring = commandArr[1];
        // If the message contains the given substring, cut it out, reverse it and add it at the end of the message. 
        // This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
        // If not, print "error".

        if (concealedMessage.Contains(substring))
        {
            string reversedSubstring = string.Empty;
            for (int i = substring.Length-1; i >= 0; i--)
            {
                reversedSubstring += substring[i];
            }
            int index = concealedMessage.IndexOf(substring);
            concealedMessage = concealedMessage.Remove(index, substring.Length);
            concealedMessage += reversedSubstring;

        }
        else
        {
            Console.WriteLine("error");
            continue;
        }


        Console.WriteLine(concealedMessage);
    }
    else if (commandArr[0] == "ChangeAll") // ChangeAll:|:{substring}:|:{replacement}":
    {
        string substring = commandArr[1];
        string replacement = commandArr[2];
        // Changes all occurrences of the given substring with the replacement text.
        while (concealedMessage.Contains(substring))
        {
            concealedMessage = concealedMessage.Replace(substring, replacement);
        }
        Console.WriteLine(concealedMessage);
    }
}
Console.WriteLine($"You have a new text message: {concealedMessage}");
