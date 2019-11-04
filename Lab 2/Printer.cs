using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    static class Printer
    {
        public static void PrintStudentNames(Section section)
        {
            var names = from student in section.Students select student.FullName;
            Console.WriteLine("FullName");
            Console.WriteLine(string.Join("\n", names));
        }

        public static void PrintAssignmentGrades(Assignment assignment, IEnumerable<Grade> grades) {
            var filteredGrades = from grade in grades where grade.Assignment == assignment select grade.Student.FullName + '\t' + grade.StudentTotal;
            Console.WriteLine("FullName\tStudentTotal");
            Console.WriteLine(string.Join("\n", filteredGrades));
        }

        public static void PrintAssignmentStudentGrade(Grade grade)
        {
            Console.WriteLine("FullName(StudentID)\tAssignmentName\tStudentTotal");
            Console.WriteLine(grade.Student.FullName + '(' + grade.Student.StudentID + ')' + '\t' + grade.Assignment.AssignmentName + '\t' + grade.StudentTotal);
        }
    }
}
