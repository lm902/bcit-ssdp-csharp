using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Grade
    {
        private decimal studentTotal { get; set; }

        public Assignment Assignment { get; set; }

        public Student Student { get; set; }

        public decimal StudentTotal
        {
            get
            {
                return this.studentTotal;
            }
            set
            {
                if (this.Assignment == null)
                {
                    throw new MemberAccessException("Assignment must be set before student total");
                }
                if (value > Assignment.Total || 0 > value)
                {
                    throw new ArgumentOutOfRangeException("Student total must be in range of 0 to the assignment total");
                }
                this.studentTotal = value;
            }
        }
    }
}
