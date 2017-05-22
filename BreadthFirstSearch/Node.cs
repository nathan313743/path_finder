using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Node
    {
        public Point Location { get; set; }

        public bool IsValid { get; set; } = true;

        public bool IsVisited { get; set; }

        public Node(int x, int y)
        {
            Location = new Point(x, y);
        }

        public Node(int x, int y, bool isValid) : this(x, y)
        {
            IsValid = false;
        }

        public Node PreviousNode { get; set; }

        public override string ToString()
        {
            return $"X:{Location.X}, Y:{Location.Y}";
        }
    }
}