using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    internal class Program2
    {
        private static string[,] GetGrid()
        {
            var gridSize = 4;
            var grid = new string[4, 4];

            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    grid[i, j] = "Empty";
                }
            }

            grid[0, 0] = "Start";
            grid[2, 2] = "Goal";

            grid[1, 1] = "Obstacle";
            grid[2, 1] = "Obstacle";
            grid[3, 1] = "Obstacle";
            grid[1, 2] = "Obstacle";

            return grid;
        }

        //private static void Main(string[] args)
        //{
        //    string[,] grid = GetGrid();
        //    var result = Go(new Point(0, 0), grid);
        //    Console.WriteLine(result);
        //    Console.ReadLine();
        //}

        private static Location ExploreInDirection(Location currentLocation, string direction, string[,] grid)
        {
            var newPath = string.Concat(currentLocation.Path, ",", direction);

            int dft = currentLocation.Point.Y;
            int dfl = currentLocation.Point.X;

            if (direction == "North")
            {
                dft -= 1;
            }
            else if (direction == "East")
            {
                dfl += 1;
            }
            else if (direction == "South")
            {
                dft += 1;
            }
            else if (direction == "West")
            {
                dfl -= 1;
            }

            var newLocation = new Location()
            {
                Point = new Point(dfl, dft),
                Path = newPath,
                Status = "Unknown"
            };

            newLocation.Status = LocationStatus(newLocation, grid);

            if (newLocation.Status == "Valid")
            {
                grid[newLocation.Point.X, newLocation.Point.Y] = "Visited";
            }

            return newLocation;
        }

        private static string LocationStatus(Location location, string[,] grid)
        {
            int gridSize = grid.GetLength(0);

            if (location.Point.X < 0 || location.Point.X >= gridSize || location.Point.Y < 0 || location.Point.Y >= gridSize)
            {
                return "Invalid";
            }
            else if (grid[location.Point.X, location.Point.Y] == "Goal")
            {
                return "Goal";
            }
            else if (grid[location.Point.X, location.Point.Y] != "Empty")
            {
                return "Blocked";
            }
            else
            {
                return "Valid";
            }
        }

        private static string Go(Point startingPoint, string[,] grid)
        {
            var queue = new Queue<Location>();
            var location = new Location()
            {
                Point = startingPoint,
                Status = "Start"
            };
            queue.Enqueue(location);

            while (queue.Count > 0)
            {
                var currentLocation = queue.Dequeue();

                var newLocation = ExploreInDirection(currentLocation, "North", grid);
                if (newLocation.Status == "Goal")
                {
                    return newLocation.Path;
                }
                else if (newLocation.Status == "Valid")
                {
                    queue.Enqueue(newLocation);
                }

                newLocation = ExploreInDirection(currentLocation, "East", grid);
                if (newLocation.Status == "Goal")
                {
                    return newLocation.Path;
                }
                else if (newLocation.Status == "Valid")
                {
                    queue.Enqueue(newLocation);
                }

                newLocation = ExploreInDirection(currentLocation, "South", grid);
                if (newLocation.Status == "Goal")
                {
                    return newLocation.Path;
                }
                else if (newLocation.Status == "Valid")
                {
                    queue.Enqueue(newLocation);
                }

                newLocation = ExploreInDirection(currentLocation, "West", grid);
                if (newLocation.Status == "Goal")
                {
                    return newLocation.Path;
                }
                else if (newLocation.Status == "Valid")
                {
                    queue.Enqueue(newLocation);
                }
            }

            return string.Empty;
        }
    }

    internal class Location
    {
        public Point Point { get; set; }

        public string Path { get; set; }

        public string Status { get; set; }
    }
}