using System;
using System.IO;

namespace DeleteThumbsdb
{
    class Program
    {
        static string stdir = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            DeleteFiles(stdir);
            Console.WriteLine("何かキーを押してください…");
            Console.ReadKey();
        }

        static void DeleteFiles(string dir)
        {
            var files = Directory.EnumerateFiles(dir);
            string[] dirs = null;

            foreach (var s in files)
            {
                if (s.EndsWith("Thumbs.db"))
                {
                    try
                    {
                        Console.WriteLine(s);
                        File.Delete(s);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("削除失敗 -----------------------------------------------");
                        Console.WriteLine(s);
                        Console.WriteLine(e.ToString());
                        Console.WriteLine("--------------------------------------------------------");
                    }
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
