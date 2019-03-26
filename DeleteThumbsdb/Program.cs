using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DeleteThumbsdb
{
    class Program
    {
        static string stdir = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            DeleteFiles(stdir);
        }

        static void DeleteFiles(string dir)
        {
            var files = Directory.EnumerateFiles(dir);
            string[] dirs = null;

            foreach (var s in files)
            {
                if (s.EndsWith("Thumbs.db"))
                {
                    Console.WriteLine(s);
                    File.Delete(s);
                }
            }

            dirs = Directory.GetDirectories(dir);
            if (dirs != null)
            {
                foreach (string s in dirs)
                {
                    DeleteFiles(s);
                }
            }
        }
    }
}
