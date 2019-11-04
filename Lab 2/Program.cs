using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var section = new Section { SectionName = "Section 1", SectionNumber = "1" };
            var philWeier = new Student { FirstName = "Phil", LastName = "Weier", StudentID = "A00948735" };
            var philWeier2 = new Student { FirstName = "Phil", LastName = "Weier", StudentID = "A00948735" };
            var philWeier3 = new Student { FirstName = "Phil", LastName = "Weier", StudentID = "A00948735" };
            section.Students.Add(philWeier);
            section.Students.Add(philWeier2);
            section.Students.Add(philWeier3);
            var assignment = new Assignment { AssignmentName = "inClass2_cs Lab", Section = section, Total = 100 };
            var philsGrade = new Grade { Assignment = assignment, Student = philWeier, StudentTotal = 5 };
            var philsGrade2 = new Grade { Assignment = assignment, Student = philWeier2, StudentTotal = 5 };
            var philsGrade3 = new Grade { Assignment = assignment, Student = philWeier3, StudentTotal = 5 };
            var grades = new List<Grade>();
            grades.Add(philsGrade);
            grades.Add(philsGrade2);
            grades.Add(philsGrade3);
            Console.WriteLine("Test PrintStudentNames");
            Printer.PrintStudentNames(section);
            Console.WriteLine("\nTest PrintAssignmentGrades");
            Printer.PrintAssignmentGrades(assignment, grades);
            Console.WriteLine("\nTest PrintAssignmentStudentGrade");
            Printer.PrintAssignmentStudentGrade(philsGrade);
            // Pause before exit
            Console.ReadKey();
        }
    }
}
