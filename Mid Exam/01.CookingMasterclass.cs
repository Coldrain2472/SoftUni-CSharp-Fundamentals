// input
float budget = float.Parse(Console.ReadLine());
int students = int.Parse(Console.ReadLine());
float flourPrice = float.Parse(Console.ReadLine());
float eggPrice = float.Parse(Console.ReadLine());
float apronPrice = float.Parse(Console.ReadLine());
int freeFlourCount = 0;

// logic
// 1 student => 1 flour, 10 eggs, 1 apron
// aprons => 20% more, rounded up to the next integer
// every 5th flour is free

for (int i = 1; i <= students; i++)
{
    if (i % 5 == 0)
    {
        freeFlourCount++;
    }
}
float flourSum = (students * flourPrice) - (freeFlourCount * flourPrice);

float eggSum = (students * 10) * eggPrice;

float percentage = students* 0.2f;
float apronSum = (float)Math.Ceiling(students + percentage) * apronPrice;

float total = flourSum + eggSum + apronSum;

// output
if (budget >= total)
{
    Console.WriteLine($"Items purchased for {total:f2}$.");
}
else
{
    Console.WriteLine($"{total - budget:f2}$ more needed.");
}