using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Grid
    {
        private Node[,] _grid;
        private Node _start;
        private Node _end;

        public Grid()
        {
            _grid = GetGrid();
            _start = _grid[0, 0];
            _end = _grid[2, 2];
        }

        private static Node[,] GetGrid()
        {
            var gridSize = 4;
            var grid = new Node[4, 4];

            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    grid[i, j] = new Node(i, j);
                }
            }

            grid[1, 1].IsValid = false;
            grid[2, 1].IsValid = false;
            grid[3, 1].IsValid = false;
            grid[1, 2].IsValid = false;

            return grid;
        }

        public Node GetNode(Point point)
        {
            if (!PointIsValid(point))
            {
                return new Node(-1, -1, false);
            }

            return _grid[point.X, point.Y];
        }

        private bool PointIsValid(Point point)
        {
            int gridSize = _grid.GetLength(0);

            if (point.X < 0 || point.X >= gridSize || point.Y < 0 || point.Y >= gridSize)
            {
                return false;
            }

            return true;
        }

        public Node GetStart() => _start;

        public bool IsEnd(Node node) => _end == node;
    }
}