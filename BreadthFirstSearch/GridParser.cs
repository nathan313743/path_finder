using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class GridParser
    {
        public GridInfo ParseToGrid(string[] contents)
        {
            string dimensionsLine = contents[0];
            int widthOfMaze = int.Parse(dimensionsLine.Substring(0, dimensionsLine.IndexOf(" ")));
            int heightOfMaze = int.Parse(dimensionsLine.Substring(dimensionsLine.IndexOf(" ")));

            string startLine = contents[1];
            int startX = int.Parse(startLine.Substring(0, startLine.IndexOf(" ")));
            int startY = int.Parse(startLine.Substring(startLine.IndexOf(" ")));

            string endLine = contents[2];
            int endX = int.Parse(endLine.Substring(0, endLine.IndexOf(" ")));
            int endY = int.Parse(endLine.Substring(endLine.IndexOf(" ")));

            var grid = new Node[heightOfMaze, widthOfMaze];
            int lineCount = 3;

            for (int i = 0; i < heightOfMaze; ++i)
            {
                string[] line = contents[lineCount].Split(' ');

                for (int j = 0; j < widthOfMaze; ++j)
                {
                    var node = new Node(j, i);
                    if (line[j] == "1")
                    {
                        node.IsValid = false;
                    }

                    grid[i, j] = node;
                }

                lineCount++;
            }

            Node startNode = grid[startY, startX];
            Node endNode = grid[endY, endX];
            var gridInfo = new GridInfo()
            {
                Grid = grid,
                StartNode = startNode,
                EndNode = endNode
            };

            return gridInfo;
        }
    }
}