using System.Text.RegularExpressions;
string text = Console.ReadLine();
Regex regex = new Regex
    (@"(?<separator>#|\|)(?<itemName>[A-Za-z\s*]+)\k<separator>(?<expDate>\d{2}\/\d{2}\/\d{2})\k<separator>(?<calories>\d+)\k<separator>");
MatchCollection matches = regex.Matches(text);
int calories = 0;
foreach (Match match in matches)
{
    calories += int.Parse(match.Groups["calories"].Value);
}
int daysToLast = calories / 2000;
Console.WriteLine($"You have food to last you for: {daysToLast} days!");
foreach (Match match in matches)
{
    Console.WriteLine($"Item: {match.Groups["itemName"].Value}, Best before: {match.Groups["expDate"].Value}, Nutrition: {match.Groups["calories"].Value}");
}