using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BreadthFirstSearch.Test
{
    [TestFixture]
    public class FileToNode_Test
    {
        private string _path;
        private FileToNode _fileReader;

        [SetUp]
        public void SetUp()
        {
            _path = @"C:\Users\nflynn\Downloads\Junifer - maze_for_candidates 2017\small.txt";
            _fileReader = new FileToNode(_path);
        }

        [Test]
        public void Test()
        {
            var contents = _fileReader.ReadFile();
        }
    }
}