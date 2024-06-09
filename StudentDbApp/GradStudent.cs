using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDbApp
{
    // a grad student is a kind of student 
    internal class GradStudent : Student
    {
        public decimal TuitionCredit { get; set; }
        public string FacultyAdvisor { get; set; }

        public GradStudent(string first, string last, string email,
                        double gpa, decimal credit, string advisor)
            : base(first, last, email, gpa)
        {
            TuitionCredit = credit;
            FacultyAdvisor = advisor;
        }
        public override string ToString()
        {
            return base.ToString() + $"Credit: {TuitionCredit}\nAdvisor: {FacultyAdvisor}\n";
        }

        public override string ToStringForOutputFile()
        {
            string str = this.GetType().FullName + "\n";
            str += base.ToStringForOutputFile() + "\n";
            str += $"{TuitionCredit}\n";
            str += $"{FacultyAdvisor}";

            return str;
        }

    }
}
