string command = string.Empty;

Dictionary<string, int> foodAndQuantityAvailable = new Dictionary<string, int>();
int totalSoldQuantity = 0;

while ((command = Console.ReadLine()) != "Complete")
{
    string[] commandArr = command.Split();

	if (commandArr[0] == "Receive") // "Receive {quantity} {food}":
    {
		int quantity = int.Parse(commandArr[1]);
		string food = commandArr[2];
        if (quantity > 0)
        {
            if (foodAndQuantityAvailable.ContainsKey(food))
            {
                foodAndQuantityAvailable[food] += quantity;
            }
            else
            {
                foodAndQuantityAvailable.Add(food, quantity);
            }
        }
    }
	else if (commandArr[0] == "Sell") // 	"Sell {quantity} {food}":
    {
        int quantity = int.Parse(commandArr[1]);
        string food = commandArr[2];
        if (!foodAndQuantityAvailable.ContainsKey(food))
        {
            Console.WriteLine($"You do not have any {food}.");
        }
        else if (foodAndQuantityAvailable[food] < quantity)
        {
            Console.WriteLine($"There aren't enough {food}. You sold the last {foodAndQuantityAvailable[food]} of them.");
            totalSoldQuantity += foodAndQuantityAvailable[food];
            foodAndQuantityAvailable.Remove(food);
        }
        else
        {
            foodAndQuantityAvailable[food] -= quantity;
            totalSoldQuantity += quantity;
            Console.WriteLine($"You sold {quantity} {food}.");
            if (foodAndQuantityAvailable[food]<=0)
            {
                foodAndQuantityAvailable.Remove(food);
            }
        }
	}
}

foreach (var food in foodAndQuantityAvailable)
{
    Console.WriteLine($"{food.Key}: {food.Value}");
}

Console.WriteLine($"All sold: {totalSoldQuantity} goods");