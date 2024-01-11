int numberOfCars = int.Parse(Console.ReadLine());
Dictionary<string, int> carAndMileage = new Dictionary<string, int>();
Dictionary<string, int> carAndFuel = new Dictionary<string, int>(); 
for (int i = 0; i < numberOfCars; i++)
{
    // "{car}|{mileage}|{fuel}"
    string[] carInfo = Console.ReadLine().Split("|");
    string carName = carInfo[0];
    int mileage = int.Parse(carInfo[1]);
    int fuel = int.Parse(carInfo[2]);
    carAndMileage.Add(carName, mileage);
    carAndFuel.Add(carName, fuel);
}
string command = string.Empty;
while ((command = Console.ReadLine()) != "Stop")
{
    string[] commandArr = command.Split(" : ");
    if (commandArr[0] == "Drive") // "Drive : {car} : {distance} : {fuel}":
    {
        string carName = commandArr[1];
        int distance = int.Parse(commandArr[2]);
        int fuel = int.Parse(commandArr[3]);
       

        if (carAndFuel[carName] < fuel)
        {
            Console.WriteLine("Not enough fuel to make that ride");
            continue;
        }
        else // if (carAndFuel[carName] >= fuel)
        {
            carAndMileage[carName] += distance;
            carAndFuel[carName] -= fuel;
            Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
        }
        if (carAndMileage[carName] >= 100_000)
        {
            carAndMileage.Remove(carName);
            carAndFuel.Remove(carName);
            Console.WriteLine($"Time to sell the {carName}!");
        }
    }
    else if (commandArr[0] == "Refuel") // "Refuel : {car} : {fuel}":
    {
        string carName = commandArr[1];
        int fuel = int.Parse(commandArr[2]);

        int maxFuelCapacity = 75;
        int totalFuel = carAndFuel[carName] + fuel;
        int refueledAmount = Math.Min(fuel, maxFuelCapacity - carAndFuel[carName]);

        carAndFuel[carName] += refueledAmount;
        Console.WriteLine($"{carName} refueled with {refueledAmount} liters");
    }
    else if (commandArr[0] == "Revert") // "Revert : {car} : {kilometers}":
    {
        string carName = commandArr[1];
        int km = int.Parse(commandArr[2]);
        carAndMileage[carName] -= km;
        if (carAndMileage[carName] < 10_000)
        {
            carAndMileage[carName] = 10_000;
        }
        else
        {
            Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
        }
    }
}
// "{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."
foreach (var car in carAndMileage)
{
    Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {carAndFuel[car.Key]} lt.");
}

