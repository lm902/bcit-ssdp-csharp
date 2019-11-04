using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_2
{
    class Section
    {
        private string sectionNumber;

        public string SectionNumber
        {
            get
            {
                return this.sectionNumber;
            }
            set
            {
                if (!Regex.IsMatch(value, "^\\w+$"))
                {
                    throw new ArgumentOutOfRangeException("Section number must contain and only contains letters and/or numbers");
                }
                this.sectionNumber = value;
            }
        }

        public string SectionName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
