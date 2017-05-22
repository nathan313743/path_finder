using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Parser
    {
        private Grid _grid;

        public Parser(Grid grid)
        {
            _grid = grid;
        }

        public Node FindPath()
        {
            var queue = new Queue<Node>();
            var directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
            queue.Enqueue(_grid.GetStart());

            while (queue.Count > 0)
            {
                var currentLocation = queue.Dequeue();
                currentLocation.IsVisited = true;

                foreach (var direction in directions)
                {
                    Point newPoint = MoveDirection(currentLocation, direction);
                    Node node = _grid.GetNode(newPoint);
                    if (_grid.IsEnd(node))
                    {
                        node.PreviousNode = currentLocation;
                        return node;
                    }
                    else if (node.IsValid && !node.IsVisited)
                    {
                        node.PreviousNode = currentLocation;
                        queue.Enqueue(node);
                    }
                }
            }

            return new Node(-1, -1, false);
        }

        private Point MoveDirection(Node currentLocation, Direction direction)
        {
            Point point;

            if (direction == Direction.North)
            {
                point = new Point(currentLocation.Location.X, currentLocation.Location.Y - 1);
                return point;
            }
            if (direction == Direction.East)
            {
                point = new Point(currentLocation.Location.X + 1, currentLocation.Location.Y);
                return point;
            }
            if (direction == Direction.South)
            {
                point = new Point(currentLocation.Location.X, currentLocation.Location.Y + 1);
                return point;
            }
            else
            {
                point = new Point(currentLocation.Location.X - 1, currentLocation.Location.Y);
                return point;
            }
        }
    }
}