///////////////////////////////////////////////////////
// TINFO 200 A, Winter 2024
// UWTacoma SET, Kush Juneja
// 2024-01-09 - L1mpg - C# programming project - A auto trip milage calculator

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/////////////////////////////////////////////////////////////////////////////////
// Change History
// Date ------- Developer -- Description
// 2024-01-09 - kushjune - Creation of file to represent the calculator
// 2024-01-09 - kushjune - Acceptance tested with nominal values - accurate 

/////////////////////////////////////////////////////////////////////////////////
// This Mileage program is a basic I/O application that will calculate fuel efficiency for a typical gasoline automobile
// between visits to the fuel station. We will learn standard input and standard output as well as simple math and assignments.
// Its main purpose in the course, however, is to verify the installation, configuration, and basic use of the C# tools and
// syntax, and the methodology of creating, coding, testing, debugging, packaging, and delivering a
// typical programming assignment in this course.

namespace Milage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User Interface
            // 1) explain why the user wants to use the software
            // 2) tell them how to use it

        Console.WriteLine(
 @"*********************************************************************************************
********************** Welcome to the Amazing TINFO-200 Trip Calculator *********************

This program will calculate fuel efficiency for a typical gasoline automobile between visits to 
the gas station. We hope you like the results and find it easy way to keep track of your cardbon 
footprint. You will be led through the input of your data - follow the instructions and examples below: 
");

            // Input section
            // get the input from the user for miles driven
            // get the input from the user for gallons of fuel
            Console.Write("Enter the number of miles for this trip (ex: 310, 297, etc.)? ");
            int milesDriven = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of gallons for this trip (ex: 12.6 , 19.4, etc.)? ");
            double gallonsUsed = double.Parse(Console.ReadLine());


            // Processing section
            // divide miles by number of gallons
            // store that calculated value in a variable for later
            double mpg = milesDriven / gallonsUsed;

            // Output section
            // tell the user the results
            Console.WriteLine();
            Console.WriteLine($"The results of your trip of {milesDriven} miles that " +
                $"used {gallonsUsed} gallons is a fuel efficiency of {mpg} miles per gallon.");

            Console.WriteLine();
            Console.WriteLine("Thanks for using the amazing TINFO-200 Calculator! Tell your freinds!");
        }
    }
}