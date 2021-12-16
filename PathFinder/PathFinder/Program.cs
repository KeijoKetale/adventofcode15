using PathFinder;
using System.Linq;

var input = new Graph
{
    Chitons = File.ReadAllLines("15.txt")
    .SelectMany((line, y) =>
        line.Select((c, x) => ((x, y), new Node(x, y, c - '0'))))
    .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2)
};

// Alkutilanne
foreach(var chitonY in input.Chitons.GroupBy(x => x.Value.Y))
{
    foreach(var chiton in chitonY)
    {
        Console.Write(chiton.Value.Risk);
    }
    Console.WriteLine();
}


// Laske Dijkstralla lyhyin matka
Console.WriteLine($"Tulos: {Algo.Dijkstra(input, input.Chitons.Values.Last())}");

// Mitkä tuli käytyä läpi
foreach (var chitonY in input.Chitons.GroupBy(x => x.Value.Y))
{
    foreach (var chiton in chitonY)
    {
        if (input.Chitons.Values.Any(x => x.Visited && x == chiton.Value))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(chiton.Value.Risk);
            Console.ResetColor();
            continue;
        }

        Console.Write(chiton.Value.Risk);
    }
    Console.WriteLine();
}

