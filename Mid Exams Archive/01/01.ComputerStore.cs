// 01. Computer Store

// input
string command = Console.ReadLine();
decimal sum = 0;
decimal tax = 0;
decimal totalPrice = 0;
decimal price = 0;
decimal totalTax = 0;
// logic
while (command != "special" && command != "regular")
{
        price = decimal.Parse(command);
    
    if (price < 0) // If the total price is equal to zero, you should print "Invalid order!" on the console.
    {
        Console.WriteLine("Invalid price!");
        
    }
    else
    {
        sum += price; // 
        //if (sum <= 0)
        //{
        //    Console.WriteLine("Invalid order!");
        //}
        tax = price * 0.2m; // The taxes are 20% of each part's price you receive. 
        totalTax += tax;

    }
    
    command = Console.ReadLine();
}

// output
if (command == "special")
{
    totalPrice = (sum + totalTax) - ((sum + totalTax)* 0.1m);
}
else if (command == "regular")
{
    totalPrice = sum + totalTax;
}


if (totalPrice == 0)
{
    Console.WriteLine("Invalid order!");
    
}
else
{
    Console.WriteLine("Congratulations you've just bought a new computer!");
    Console.WriteLine($"Price without taxes: {sum:f2}$");
    Console.WriteLine($"Taxes: {totalTax:f2}$");
    Console.WriteLine("-----------");
    Console.WriteLine($"Total price: {totalPrice:f2}$");
}
