using System.Collections.Generic;

namespace PathFinder
{
    internal class Graph
    {
        public IEnumerable<Node>? Chitons { get; set; }
        static readonly (int, int)[] adjacent = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        internal IEnumerable<Node> GetNeighbors(Node current)
        {
            foreach ((int i, int j) in adjacent)
            {
                var found = Chitons?.FirstOrDefault(x => x.X == current.X + i && x.Y == current.Y + j);
                if (found != null && !found.Visited)
                {
                    yield return found;
                }
            }
        }
    }
}
