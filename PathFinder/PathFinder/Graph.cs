namespace PathFinder
{
    internal class Graph
    {
        public Dictionary<(int, int), Node>? Chitons { get; set; }
        static readonly (int, int)[] adjacent = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        internal IEnumerable<Node> GetNeighbors(Node current)
        {
            foreach ((int i, int j) in adjacent)
            {
                var key = (current.X + i, current.Y + j);
                if (Chitons.ContainsKey(key) && !Chitons[key].Visited)
                {
                    yield return Chitons[key];
                }
            }
        }
    }
}
