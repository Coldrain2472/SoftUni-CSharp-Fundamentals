using Microsoft.VisualBasic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
Dictionary<string, int> plantsAndRarity = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    // "{plant}<->{rarity}"
    string[] info = Console.ReadLine().Split("<->");
    string plant = info[0];
    int rarity = int.Parse(info[1]);
    plantsAndRarity.Add(plant, rarity);
}
Dictionary<string, List<int>> plantsAndRating = new Dictionary<string, List<int>>();
foreach (var plant in plantsAndRarity)
{
    List<int> ratings = new List<int>();
    plantsAndRating.Add(plant.Key, ratings);
}

string command = string.Empty;
while ((command = Console.ReadLine()) != "Exhibition")
{ // Note: If any given plant name is invalid, print "error"
    string[] commandArr = command.Split(" ");
    if (command.Contains("Rate")) // "Rate: {plant} - {rating}"
    {
        string plant = commandArr[1];
        int rating = int.Parse(commandArr[3]);
        // add the given rating to the plant (store all ratings)

        if (plantsAndRating.ContainsKey(plant))
        {
            plantsAndRating[plant].Add(rating); 
        }
        else
        {
            Console.WriteLine("error");
        }
    }
    else if (command.Contains("Update")) // "Update: {plant} - {new_rarity}"
    {
        string plant = commandArr[1];
        int newRarity = int.Parse(commandArr[3]);
        if (plantsAndRating.ContainsKey(plant))
        {
            plantsAndRarity[plant] = newRarity; 
        }
        else
        {
            Console.WriteLine("error");
        }
        // update the rarity of the plant with the new one
    }
    else if (command.Contains("Reset")) // 	"Reset: {plant}"
    {
        string plant = commandArr[1];
        // – remove all the ratings of the given plant
        if (plantsAndRating.ContainsKey(plant))
        {
            plantsAndRating[plant].Clear();
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}

Console.WriteLine("Plants for the exhibition:");
foreach (var currentPlant in plantsAndRarity)
{
    int plantRatingsSum = plantsAndRating[currentPlant.Key].Sum();
    int plantRatingsCount = plantsAndRating[currentPlant.Key].Count();

    if (plantRatingsCount == 0)
    {
        plantRatingsSum = 0;
        Console.WriteLine($"- {currentPlant.Key}; Rarity: {currentPlant.Value}; Rating: {0:f2}");
    }
    else
    {
        double averageRate = plantRatingsSum / (double)plantRatingsCount;
        Console.WriteLine($"- {currentPlant.Key}; Rarity: {currentPlant.Value}; Rating: {averageRate:f2}");
    }
}
