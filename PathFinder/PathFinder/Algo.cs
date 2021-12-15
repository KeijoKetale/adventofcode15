namespace PathFinder
{
    internal class Algo
    {
        internal static int Dijkstra(Graph graph, Node target)
        {
            var next = new PriorityQueue<Node, int>();
            var first = graph.Chitons?.FirstOrDefault();
            if(first == null)
            {
                return 0;
            }
            first.Distance = 0;
            next.Enqueue(first, 0);

            while (next.Count > 0)
            {
                Console.WriteLine(next.Count);
                var current = next.Dequeue();
                if (current.Visited)
                {
                    continue;
                }

                current.Visited = true;

                if (current == target)
                {
                    Console.WriteLine($"target, {target.Distance}");
                    return target.Distance;
                }

                foreach (var neighbor in graph.GetNeighbors(current))
                {
                    var alt = current.Distance + neighbor.Risk;
                    if (alt < neighbor.Distance)
                    {
                        neighbor.Distance = alt;
                    }

                    if (neighbor.Distance != int.MaxValue)
                    {
                        next.Enqueue(neighbor, neighbor.Distance);
                    }
                }
            }
            Console.WriteLine($"target, {target.Distance}");

            return target.Distance;
        }
    }
}
