// input
List<string> shoppingList = Console.ReadLine().Split("!").ToList();
string command = Console.ReadLine();

// logic
while (command != "Go Shopping!")
{
    string[] groceries = command.Split();
    if (groceries[0] == "Urgent") // Urgent {item}
      // add the item at the start of the list.  
    {
        string item = groceries[1];
        if (!shoppingList.Contains(item))
        {
            shoppingList.Insert(0, item);
        }
    }
    else if (groceries[0] == "Unnecessary") // Unnecessary {item}" 
      // remove the item with the given name, only if it exists in the list. 
    {
        string item = groceries[1];
        if (shoppingList.Contains(item))
        {
            shoppingList.Remove(item);
        }
    }
    else if (groceries[0] == "Correct") // Correct {oldItem} {newItem}" 
       // if the item with the given old name exists, change its name with the new one.
    {
        string oldItem = groceries[1];
        string newItem = groceries[2];
        if (shoppingList.Contains(oldItem))
        {
            int index = shoppingList.IndexOf(oldItem);
            shoppingList.RemoveAt(index);
            shoppingList.Insert(index, newItem);
        }
    }
    else if (groceries[0] == "Rearrange") // Rearrange {item}" 
      // if the grocery exists in the list, remove it from its current position and add it at the end of the list. 
    {
        string item = groceries[1]; 
        if (shoppingList.Contains(item))
        {
            shoppingList.Remove(item);
            shoppingList.Add(item);
        }
    }
    command = Console.ReadLine();
}
// output
Console.WriteLine(string.Join(", ", shoppingList));