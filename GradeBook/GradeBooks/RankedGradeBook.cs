using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            // Figure out how many students make up 20%
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            // Sort the students by average grade in descending order
            var sortedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            // Check if the average grade is in the top 20% of the class
            if (averageGrade >= sortedGrades[threshold - 1])
            {
                return 'A';
            }

            // Check if the average grade is in the top 40% of the class
            if (averageGrade >= sortedGrades[(threshold * 2) - 1])
            {
                return 'B';
            }

            // Check if the average grade is in the top 60% of the class
            if (averageGrade >= sortedGrades[(threshold * 3) - 1])
            {
                return 'C';
            }

            // Check if the average grade is in the top 80% of the class
            if (averageGrade >= sortedGrades[(threshold * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }
    }

}
