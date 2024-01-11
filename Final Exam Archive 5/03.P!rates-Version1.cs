string input = string.Empty;

Dictionary<string, int> cityAndPopulation = new Dictionary<string, int>();
Dictionary<string, int> cityAndGold = new Dictionary<string, int>();

while ((input = Console.ReadLine()) != "Sail")
{
    // city||population||gold
    // If you receive a city that has already been received, you have to increase the population and gold with the given values.
    string[] inputInfo = input.Split("||");
    string city = inputInfo[0];
    int population = int.Parse(inputInfo[1]);
    int gold = int.Parse(inputInfo[2]);
    if (cityAndPopulation.ContainsKey(city))
    {
        cityAndPopulation[city] += population;
        cityAndGold[city] += gold;
    }
    else
    {
        cityAndPopulation.Add(city, population);
        cityAndGold.Add(city, gold);
    }
}
string command = string.Empty;
while ((command = Console.ReadLine()) != "End")
{
    string[] commandArr = command.Split("=>");
    if (commandArr[0] == "Plunder") // "Plunder=>{town}=>{people}=>{gold}"
    {
        string town = commandArr[1];
        int people = int.Parse(commandArr[2]);
        int gold = int.Parse(commandArr[3]);
        cityAndPopulation[town] -= people;
        cityAndGold[town] -= gold;
        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

        if (cityAndPopulation[town] <= 0 || cityAndGold[town] <= 0)
        {
            cityAndPopulation.Remove(town);
            cityAndGold.Remove(town);
            Console.WriteLine($"{town} has been wiped off the map!");
        }
    }


    else if (commandArr[0] == "Prosper") // "Prosper=>{town}=>{gold}"
    {
        string town = commandArr[1];
        int gold = int.Parse(commandArr[2]);
        if (gold > 0)
        {
            cityAndGold[town] += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityAndGold[town]} gold.");
        }
        else
        {
            Console.WriteLine("Gold added cannot be a negative number!");
        }
    }

}
if (cityAndPopulation.Count > 0)
{
    Console.WriteLine($"Ahoy, Captain! There are {cityAndPopulation.Count} wealthy settlements to go to:");
    foreach (var city in cityAndPopulation)
    {
        Console.WriteLine($"{city.Key} -> Population: {city.Value} citizens, Gold: {cityAndGold[city.Key]} kg");
    }
   
}
else
{
    Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
}
