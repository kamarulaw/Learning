using System;
using System.Collections.Generic;
namespace GradeBook
{
    public class Statistics
    {
        // Fields
        public double minGrade;
        public double maxGrade;
        public char letter;
        public double sum;
        public int count;

        // Properties
        public double Average
        {
            get
            {
                return sum / count;
            }
        }

        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70.0:
                       return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        // Constructor
        public Statistics()
        {
            minGrade = double.MaxValue;
            maxGrade = double.MinValue;
            sum = 0.0;
            count = 0; 
        }

        // Methods
        public void Add(double number)
        {
            this.count++;
            this.sum += number;
            this.minGrade = Math.Min(this.minGrade, number);
            this.maxGrade = Math.Max(this.maxGrade, number);
        }
    }
}