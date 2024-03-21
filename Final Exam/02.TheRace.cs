using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;


string pattern = @"([#$%*&])(?<name>[A-z]+)(\1)=(?<lenght>\d+)!!(?<code>.+)";
string input = Console.ReadLine();

while (true)
{
    Regex order = new Regex(pattern);
    if (order.IsMatch(input))
    {
        string name = order.Match(input).Groups["name"].Value;
        int lenght = int.Parse(order.Match(input).Groups["lenght"].Value);
        string code = order.Match(input).Groups["code"].Value;
        if (lenght == code.Length)
        {
            StringBuilder codee = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                char symbol = (char)(code[i] + lenght);
                codee.Append(symbol);
            }
            
            Console.WriteLine($"Coordinates found! {name} -> {codee}");
            return;
        }
        else
        {
            Console.WriteLine("Nothing found!");
        }
    }
    else
    {
        Console.WriteLine("Nothing found!");
    }

    input = Console.ReadLine();
}