namespace PathFinder
{
    internal class Algo
    {
        internal static int Dijkstra(Graph graph, Node target)
        {
            var next = new PriorityQueue<Node, int>();
            graph.Chitons[(0, 0)].Distance = 0;
            next.Enqueue(graph.Chitons[(0, 0)], 0);

            while (next.Count > 0)
            {
                var current = next.Dequeue();
                if (current.Visited)
                {
                    continue;
                }

                current.Visited = true;

                if (current == target)
                {
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

            return target.Distance;
        }
    }
}
