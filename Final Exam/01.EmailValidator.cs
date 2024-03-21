using System;
using System.Text;

string email = Console.ReadLine();
string command = string.Empty;

while ((command = Console.ReadLine()) != "Complete")
{
    string[] commandArr = command.Split();

    if (commandArr[0] == "Make")
    {
        if (commandArr[1] == "Upper")
        {
            email = email.ToUpper();
            Console.WriteLine(email);
        }
        else
        {
            email = email.ToLower();
            Console.WriteLine(email);
        }
    }
    else if (commandArr[0] == "GetDomain") // "GetDomain {count}"
    {
        // Print the last count of characters of the email.
        int count = int.Parse(commandArr[1]);
        if (count >= 0 && count < email.Length)
        {
            Console.WriteLine(email.Substring(email.Length - count));
        }
        else
        {
            Console.WriteLine("Invalid count for GetDomain command.");
        }
    }
    else if (commandArr[0] == "GetUsername")
    {
        // Print the substring from the start of the email until the "@" symbol.
        int atIndex = email.IndexOf('@');
        if (atIndex != -1)
        {
            Console.WriteLine(email.Substring(0, atIndex));
        }
        else
        {
            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
        }
    }
    else if (commandArr[0] == "Replace") // "Replace {char}"
    {
        // Replace all occurrences of the given chars with a dash "-"
        string symbol = commandArr[1];
        string newSymbol = "-";
        email = email.Replace(symbol, newSymbol);
        Console.WriteLine(email);
    }
    else if (commandArr[0] == "Encrypt")
    {
        // Get the ASCII value of each symbol.
        // Print the result on a single line separated by a single space.
        byte[] asciiBytes = Encoding.ASCII.GetBytes(email);
        Console.WriteLine(string.Join(" ", asciiBytes));
    }
}