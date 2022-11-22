using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine();
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            // Query Syntax
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file; 
            foreach (var file in query.Take(5))
            {

                Console.WriteLine($"{file.Name}: {file.Length}");
            }
            Console.WriteLine();

            // Method Syntax
            var query2 = new DirectoryInfo(path).GetFiles()
                                .OrderByDescending(f => f.Length)
                                .Take(5);
            foreach (var file in query2)
            {
                Console.WriteLine($"{file.Name}: {file.Length}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name}: {files[i].Length}");
            }
        }
    }
}