//////////////////////////////////////
///////////Change History ///////////
///

using System;

namespace StudentDbApp
{
    

    // The Student class represents a single record in the database for a student
    // in the school. We'll determine what parameters we want to store in that record
    // the Student class is an example of encapsualtion, the first "feature" or mechanism of 
    // any OO language. It provides a software component that holds all the STATE and BEHAVIOR having
    // to do with an object of that type.

    // Encapsulation is covered in Ch10
    // Inheritance - Ch11
    // Polymorphism - Ch12
    internal abstract class Student //: object
    {

        // what attributes do we want to store
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // intuitively chose as the primary key for a record
        public string EmailAddress { get; set; }
        public double GradePtAvg { get; set; }

        // fully specified ctor (full spec)
        public Student(string fName, string lName, string email, double gpa)
        {
            FirstName = fName;
            LastName = lName;
            EmailAddress = email;
            GradePtAvg = gpa;

        }

        // do nothing no-arg (same as defualt)
        public Student()
        {
        }

        public override string ToString()
        {
            // return $"Name: {FirstName} {LastName}, Email: {EmailAddress}, GPA: {GradePtAvg:F2}";

            // 1- declare a temp string
            string str = string.Empty;

            // 2- build up that string with the info from this object
            str += "\n******** Student Rec ********\n";
            str += $"First: {FirstName}\n";
            str += $"Last: {LastName}\n";
            str += $"Email: {EmailAddress}\n";
            str += $"GPA: {GradePtAvg:F2}\n";

            // 3- return the string
            return str;
        }

        // we need a way for a student obj to print itself
        // formatted for the output file - only data, no labels, etc.
        public virtual string ToStringForOutputFile()
        {
            // 1- declare a temp string
            string str = string.Empty;

            // 2- build up that string with the info from this object
            str += $"{FirstName}\n";
            str += $"{LastName}\n";
            str += $"{EmailAddress}\n";
            str += $"{GradePtAvg:F2}";

            // 3- return the string
            return str;
        }
    }
}