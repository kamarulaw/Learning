using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // announced to relevant pieces of code that we have added a grade to our gradebook

    public class InMemoryBook : Book
    {
        private double minGrade;
        private double maxGrade;
        private double averageGrade; 
        private List<double> grades;
        public string name;
        private const string CATEGORY = "Science";
        public override event GradeAddedDelegate GradeAdded;

        /*
         * const
         * stronger than readonly
         * can only be written to when delcaring a variable
         * static, meaning not a piece of state specific to a given object
         * const fields are associated with the class
        */

        public InMemoryBook(string name) : base(name)
        {
            this.name = name;
            this.minGrade = double.MaxValue;
            this.maxGrade = double.MinValue;
            this.averageGrade = 0; 
            this.grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break; 
                default:
                    AddGrade(0);
                    break; 
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void computeMinGrade()
        {
            foreach (var number in grades)
            {
                this.minGrade = Math.Min(this.minGrade, number);
            }
        }

        public void computeMaxGrade()
        {
            foreach (var number in grades)
            {
                this.maxGrade = Math.Max(this.maxGrade, number);
            }
        }

        public void computeAverageGrade()
        {
            foreach (var number in grades)
            {
                this.averageGrade += number; 
            }
            this.averageGrade /= grades.Count; 
        }

        public void viewMinGrade()
        {
            Console.WriteLine($"The lowest grade is {this.minGrade}");
        }

        public void viewMaxGrade()
        {
            Console.WriteLine($"The highest grade is {this.maxGrade}");
        }

        public void viewAverageGrade()
        {
            Console.WriteLine($"The average grade is {this.averageGrade}");
        }

        public void ShowStatistics()
        {
            computeMinGrade();
            computeMaxGrade(); 
            computeAverageGrade();

            viewMinGrade();
            viewMaxGrade();
            viewAverageGrade(); 
        }

        // REFACTORED CODE
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);   
            }

            return result; 
        }

    }
}