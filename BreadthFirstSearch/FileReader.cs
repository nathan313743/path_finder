using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class FileReader
    {
        private string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string[] ReadFile()
        {
            return File.ReadAllLines(_path);
        }
    }
}