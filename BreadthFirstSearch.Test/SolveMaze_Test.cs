using NUnit.Framework;

namespace BreadthFirstSearch.Test
{
    [TestFixture]
    public class SolveMaze_Test
    {
        private string _path;
        private FileReader _fileReader;

        [SetUp]
        public void SetUp()
        {
            //_path = "../../../maze/small.txt";
            // _path = "../../../maze/input.txt";
            // _path = "../../../maze/sparse_medium.txt";
            _path = "../../../maze/large_input.txt";

            _fileReader = new FileReader(_path);
        }

        [Test]
        public void Test()
        {
            var contents = _fileReader.ReadFile();
            var info = new GridParser().ParseToGrid(contents);
            var grid = new Grid(info);
            var pathFinder = new PathFinder(grid);
            var list = pathFinder.FindPath();
            grid.PrintPath(list);
        }
    }
}