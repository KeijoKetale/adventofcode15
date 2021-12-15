namespace PathFinder
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Risk { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public bool Visited { get; set; } = false;

        public Node(int x, int y, int risk)
        {
            X = x;
            Y = y;
            Risk = risk;
        }
    }
}
