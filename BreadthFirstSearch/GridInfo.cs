using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class GridInfo
    {
        public Node[,] Grid { get; set; }

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }
    }
}