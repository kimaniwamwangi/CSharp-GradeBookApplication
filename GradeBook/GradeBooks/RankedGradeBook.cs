using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        double[] SortedGrades;
        double TwentyPercent;


        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
            SortedGrades = new double[Students.Count];
            TwentyPercent = Students.Count * 0.2;
            PreCalculateGrades();
        }

        void PreCalculateGrades()
        {
         
            int index = 0;
            foreach (Student student in Students)
            {
                SortedGrades[index] = student.AverageGrade;
                index++;
            }

            Array.Sort(SortedGrades);
        }

        char DetermineGradeGroup(double averageGrade)
        {
            char[] grades = new [] { 'A', 'B', 'C', 'D', 'F'};
            int start = 0;
            int count = 0;
            foreach(double average in SortedGrades)
            {
                if(count + 1 > TwentyPercent)
                {
                    TwentyPercent *= 2;
                    start++;
                }
                count++;

            }

            return grades[start];
            
        }

        public override char GetLetterGrade(double averageGrade)
        {
            CheckCanCalculate();
            return DetermineGradeGroup(averageGrade);
        }

        void CheckCanCalculate()
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
        }
    }
}
