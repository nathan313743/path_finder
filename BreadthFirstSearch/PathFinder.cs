using System.Collections.Generic;
using System.Drawing;

namespace BreadthFirstSearch
{
    public class PathFinder
    {
        private readonly Grid _grid;

        public PathFinder(Grid grid)
        {
            _grid = grid;
        }

        public List<Node> FindPath()
        {
            var queue = new Queue<Node>();
            var directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West };
            queue.Enqueue(_grid.GetStart());
            _grid.GetStart().IsVisited = true;

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
                        return PathList(node);
                    }
                    else if (node.IsValid && !node.IsVisited)
                    {
                        node.PreviousNode = currentLocation;
                        node.IsVisited = true;
                        queue.Enqueue(node);
                    }
                }
            }

            return new List<Node>();
        }

        private Point MoveDirection(Node currentLocation, Direction direction)
        {
            Point point;

            if (direction == Direction.North)
            {
                point = new Point(currentLocation.Point.X, currentLocation.Point.Y - 1);
                return point;
            }
            if (direction == Direction.East)
            {
                point = new Point(currentLocation.Point.X + 1, currentLocation.Point.Y);
                return point;
            }
            if (direction == Direction.South)
            {
                point = new Point(currentLocation.Point.X, currentLocation.Point.Y + 1);
                return point;
            }
            else
            {
                point = new Point(currentLocation.Point.X - 1, currentLocation.Point.Y);
                return point;
            }
        }

        private List<Node> PathList(Node node)
        {
            var list = new List<Node>();

            while (node.PreviousNode != null)
            {
                list.Add(node);
                node = node.PreviousNode;
            }

            return list;
        }
    }
}