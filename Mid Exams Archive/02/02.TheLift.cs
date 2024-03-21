// input
int peopleWaitingForLift = int.Parse(Console.ReadLine());
int[] wagon = Console.ReadLine().Split().Select(int.Parse).ToArray();

// logic
// Every wagon should have a maximum of 4 people on it

int peopleOnTheCurrentWagon = 0;
int peopleonTheLift = 0;
bool NoMorePeople = false;

for (int i = 0; i < wagon.Length; i++)
{
    while (wagon[i] < 4)
    {
        wagon[i]++;
        peopleOnTheCurrentWagon++;
        if (peopleonTheLift + peopleOnTheCurrentWagon == peopleWaitingForLift)
        {
            NoMorePeople = true;
            break;
        }
    }
    peopleonTheLift += peopleOnTheCurrentWagon;
    if (NoMorePeople)
    {
        break;
    }
    peopleOnTheCurrentWagon = 0;
}
// output
if (peopleWaitingForLift > peopleonTheLift)
{
    Console.WriteLine($"There isn't enough space! {peopleWaitingForLift - peopleonTheLift} people in a queue!");
    Console.WriteLine(string.Join(" ", wagon));
}
else if (peopleWaitingForLift < wagon.Length * 4 && wagon.Any(w => w < 4))
{
    Console.WriteLine("The lift has empty spots!");
    Console.WriteLine(string.Join(" ", wagon));
}
else if (wagon.All(w => w == 4) && NoMorePeople == true)
{
    Console.WriteLine(string.Join(" ", wagon));
}