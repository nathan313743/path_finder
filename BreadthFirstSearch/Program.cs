using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Grid grid = new Grid();
            Parser parse = new Parser(grid);
            Node node = parse.FindPath();

            Stack<Node> stack = new Stack<Node>();

            while (node.PreviousNode != null)
            {
                stack.Push(node);
                node = node.PreviousNode;
            }

            foreach (var n in stack)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }
    }
}