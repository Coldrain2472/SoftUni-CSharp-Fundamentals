int answeredQuestions = 0;

int hours = 0;
for (int i = 0; i < 3; i++)
{
    int efficiency = int.Parse(Console.ReadLine()); // per hour
    answeredQuestions += efficiency; // per hour
}
int studentsCount = int.Parse(Console.ReadLine());
 // per hour
while (studentsCount > 0)
{
    studentsCount -= answeredQuestions;
    hours++;
    if (hours % 4 == 0)
    {
        hours++;
    }
    
}
Console.WriteLine($"Time needed: {hours}h.");