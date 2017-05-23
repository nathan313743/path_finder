using System.Drawing;

namespace BreadthFirstSearch
{
    public class Node
    {
        public Node(int x, int y)
        {
            Point = new Point(x, y);
        }

        public Node(int x, int y, bool isValid) : this(x, y)
        {
            IsValid = false;
        }

        public bool IsValid { get; set; } = true;

        public bool IsVisited { get; set; }

        public Point Point { get; set; }

        public Node PreviousNode { get; set; }

        public override string ToString()
        {
            return $"X:{Point.X}, Y:{Point.Y}";
        }
    }
}