using System;
using System.IO; 
using System.Collections.Generic; 

namespace GradeBook
{
    public class DiskBook : Book
    {
        public string name;
        public override event GradeAddedDelegate GradeAdded;
        private const string CATEGORY = "Math";

        public DiskBook(string name) : base(name)
        {
            this.name = name;
        }
        
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText(name + ".txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            Console.WriteLine(this.name + ".txt");
            using (var reader = File.OpenText(this.name+".txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}