using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
       

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
          
        }

       

        public override char GetLetterGrade(double averageGrade)
        {
            CheckCanCalculate();

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[threshold - 1])
                return 'A';
            else if (averageGrade >= grades[threshold * 2 - 1])
                return 'B';
            else if (averageGrade >= grades[threshold * 3 - 1])
                return 'C';
            else if (averageGrade >= grades[threshold * 4 - 1])
                return 'D';

            return 'F';
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
