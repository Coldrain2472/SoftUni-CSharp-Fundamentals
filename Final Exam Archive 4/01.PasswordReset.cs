string password = Console.ReadLine();
string command = string.Empty;
while ((command = Console.ReadLine()) != "Done")
{
    string[] commandArr = command.Split();
	if (commandArr[0] == "TakeOdd")
	// Takes only the characters at odd indices and concatenates them to obtain the new raw password and then prints it.
	{
		string newPassword = string.Empty;
		for (int i = 0; i < password.Length; i++)
		{
			if (i % 2 != 0)
			{
				newPassword += password[i];
			}
		}
		password = newPassword;
		Console.WriteLine(password);
	}
	else if (commandArr[0] == "Cut") // Cut {index} {length}"
	{
		int index = int.Parse(commandArr[1]);
		int length = int.Parse(commandArr[2]);
		// Gets the substring with the given length starting from the given index from the password
		// and removes its first occurrence,
		// then prints the password on the console.
		string newPassword = password;
		string substring = newPassword.Substring(index, length);
		if (password.Contains(substring))
		{
			password = password.Remove(index, length);
		}
		Console.WriteLine(password);
	}
	else if (commandArr[0] == "Substitute") // "Substitute {substring} {substitute}"
	{
		//If the raw password contains the given substring,
		//replace all of its occurrences with the substitute text given
		//and print the result.
		// If it doesn't, prints "Nothing to replace!".
		string substring = commandArr[1];
		string substitute = commandArr[2];
		if (password.Contains(substring))
		{
			password = password.Replace(substring, substitute);
			Console.WriteLine(password);
		}
		else
		{
			Console.WriteLine("Nothing to replace!");
		}
    }
}
Console.WriteLine($"Your password is: {password}");
