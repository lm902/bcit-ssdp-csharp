using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_2
{
    class Student
    {
        private string studentID;

        public string StudentID
        {
            get
            {
                return this.studentID;
            }
            set
            {
                if (!Regex.IsMatch(value, "^[Aa]\\d{8}$"))
                {
                    throw new ArgumentOutOfRangeException("This value is not a student ID");
                }
                this.studentID = value.ToUpper();
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + ' ' + this.LastName;
            }
        }
    }
}
