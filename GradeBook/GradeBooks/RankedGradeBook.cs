﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
       

        public RankedGradeBook(string name, bool weighted ) : base(name, weighted)
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
            if(Students.Count() < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
