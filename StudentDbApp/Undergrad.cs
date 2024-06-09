using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StudentDbApp
{
    public enum YearRank
    {
        // our YearRank type is represent the student's
        // progress through the program
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4
    }

    internal class Undergrad : Student
    {
        public YearRank Rank { get; set; }
        public string DegreeMajor { get; set; }

        public Undergrad(string first, string last, string email, 
                        double gpa, YearRank year, string major)
            : base(first, last, email, gpa)
        {
            Rank = year;
            DegreeMajor = major;
        }
        public override string ToString()
        {
            return base.ToString() + $"Year: {Rank}\nMajor: {DegreeMajor}\n";
        }

        public override string ToStringForOutputFile()
        {
            string str = this.GetType().FullName + "\n";
            str += base.ToStringForOutputFile() + "\n";
            str += $"{Rank}\n";
            str += $"{DegreeMajor}";

            return str;
        }
    }
}
