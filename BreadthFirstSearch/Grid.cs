using System;
using System.Collections.Generic;
using System.Drawing;

namespace BreadthFirstSearch
{
    public class Grid
    {
        private readonly Node _endNode;
        private readonly Node[,] _grid;
        private readonly Node _startNode;

        public Grid(GridInfo gridInfo)
        {
            _grid = gridInfo.Grid;
            _startNode = gridInfo.StartNode;
            _endNode = gridInfo.EndNode;
        }

        public Node GetNode(Point point)
        {
            if (!PointIsValid(point))
            {
                return new Node(-1, -1, false);
            }

            return _grid[point.Y, point.X];
        }

        public Node GetStart() => _startNode;

        public bool IsEnd(Node node) => _endNode == node;

        public void PrintGrid()
        {
            for (int y = 0; y < _grid.GetLength(0); ++y)
            {
                for (int x = 0; x < _grid.GetLength(1); ++x)
                {
                    if (_grid[y, x].IsValid)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintPath(List<Node> pathNode)
        {
            for (int y = 0; y < _grid.GetLength(0); ++y)
            {
                for (int x = 0; x < _grid.GetLength(1); ++x)
                {
                    var n = _grid[y, x];
                    if (n == _startNode)
                    {
                        Console.Write("S");
                    }
                    else if (n == _endNode)
                    {
                        Console.Write("E");
                    }
                    else if (pathNode.Contains(n))
                    {
                        Console.Write("X");
                    }
                    else if (_grid[y, x].IsValid)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool PointIsValid(Point point)
        {
            if (point.X < 0
                || point.X >= _grid.GetLength(1)
                || point.Y < 0
                || point.Y >= _grid.GetLength(0))
            {
                return false;
            }

            return true;
        }
    }
}