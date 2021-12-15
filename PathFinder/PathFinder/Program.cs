using PathFinder;



var input = new Graph
{
    Chitons = File.ReadAllLines("15.txt")
    .SelectMany((line, y) =>
        line.Select((c, x) => new Node(x, y, c - '0')))
};

foreach(var chiton in input.Chitons)
{
    Console.WriteLine($"x: {chiton.X}, y: {chiton.Y} risk: {chiton.Risk}");
}


// Laske Dijkstralla lyhyin matka
Console.WriteLine($"Tulos: {Algo.Dijkstra(input, input.Chitons.Last())}");

