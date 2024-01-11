using System.Text.RegularExpressions;

string inputPlaces = Console.ReadLine();

Regex placeRegex = new Regex(@"(?<separator>=|\/)(?<destination>[A-Z][A-Za-z]{2,})\k<separator>");
MatchCollection placesMatch = placeRegex.Matches(inputPlaces);
List<string> placesList = new List<string>();

int points = 0;
foreach (Match place in placesMatch)
{
    points += place.Groups["destination"].Value.Length;
    placesList.Add(place.Groups["destination"].Value);
}

Console.WriteLine($"Destinations: {String.Join(", ", placesList)}");
Console.WriteLine($"Travel Points: {points}");
