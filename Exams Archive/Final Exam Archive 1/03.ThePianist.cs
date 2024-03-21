int numberOfPieces = int.Parse(Console.ReadLine());
Dictionary<string, string> pieceAndComposer = new Dictionary<string, string>();
Dictionary<string, string> pieceAndKey = new Dictionary<string, string>();
for (int i = 0; i < numberOfPieces; i++)
{
    string[] pieces = Console.ReadLine().Split("|");
    // "{piece}|{composer}|{key}".
    string piece = pieces[0];
    string composer = pieces[1];
    string key = pieces[2];
    pieceAndComposer.Add(piece, composer);
    pieceAndKey.Add(piece, key);
}
string command = string.Empty;
while ((command = Console.ReadLine()) != "Stop")
{
    string[] commandArray = command.Split("|");
    if (commandArray[0] == "Add") // •	"Add|{piece}|{composer}|{key}":
    {
        string piece = commandArray[1];
        string composer = commandArray[2];
        string key = commandArray[3];
        if (pieceAndComposer.ContainsKey(piece))
        {
            // If the piece is already in the collection, print: "{piece} is already in the collection!"
            Console.WriteLine($"{piece} is already in the collection!");
        }
        else
        {
            pieceAndComposer.Add(piece, composer);
            pieceAndKey.Add(piece, key);
            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
        }
    }
    else if (commandArray[0] == "Remove") // •	"Remove|{piece}":
    {
        string piece = commandArray[1];
        // o	If the piece is in the collection, remove it and print: "Successfully removed {piece}!"
        if (pieceAndComposer.ContainsKey(piece))
        {
            pieceAndComposer.Remove(piece);
            Console.WriteLine($"Successfully removed {piece}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }

    }
    else if (commandArray[0] == "ChangeKey") // •	"ChangeKey|{piece}|{new key}":
    {
        string piece = commandArray[1];
        string newKey = commandArray[2];
        if (pieceAndKey.ContainsKey(piece))
        {
            pieceAndKey[piece] = newKey;
            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
        }
        else
        {
            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
        }
    }
}
foreach (var piece in pieceAndComposer)
{
    Console.WriteLine($"{piece.Key} -> Composer: {piece.Value}, Key: {pieceAndKey[piece.Key]}");
}
