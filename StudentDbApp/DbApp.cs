using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentDbApp
{
    // this will represent the application itself
    // known in OO "Patterns" as a Singleton object pattern
    internal class DbApp
    {
        // what is the typical behavior that we need form a database
        // 1- store data (students) - we need some kind of collection class that will store students
        private List<Student> students = new List<Student>();

        // 2- we need typical operations on a database? CRUD operations are fundamental to any db
        // a) add a student record to the database [C]reate a student record - if it isn't already in the db
        // b) find a student record in the database [R]ead a student record - print if the rec IS in the database
        // c) edit a student record in the database [U]pdate a student record - if it IS in the db
        // d) delete a student record from the database [D]elete a student record - if it IS in the database

        // utility type methods or operations - eg - ctor, tostring methods, etc
        public DbApp()
        {
            // test putting data into the list - and output to the shell
            //DbAppTest1();

            ReadStudentDataFromInputFile();

            //run the main database app "processing "loop"
            RunDatabaseApp();

            // test outputing the data to the output file
            WriteDataToOutputFile();
        }

        private void ReadStudentDataFromInputFile()
        {
            // 1 - create a file stream object and connect it to the file on disk
            StreamReader inFile = new StreamReader(StudentInputFile);

            // 2 - use the file object to actually read the input data
            string studentType = string.Empty;

            // dual purpose statement here
            // 1 - read in a string from the file
            // 2 - set the condition for the loop to continue by comparing to null
            while ((studentType = inFile.ReadLine()) != null)
            {
                // gather all data from a single student from the file
                string first = inFile.ReadLine();
                string last = inFile.ReadLine();
                string email = inFile.ReadLine();
                double gpa = double.Parse(inFile.ReadLine());


                if (studentType == "StudentDbApp.Undergrad")
                {
                    // go grab the stuff that is specific to undergrads only
                    YearRank year = (YearRank)Enum.Parse(typeof(YearRank), inFile.ReadLine());
                    string major = inFile.ReadLine();

                    // now make a new student and add them to the list<>
                    Student stu = new Undergrad(first, last, email, gpa, year, major);
                    students.Add(stu);
                    Console.WriteLine($"Adding new student: {stu}");
                }
                else if (studentType == "StudentDbApp.GradStudent")
                {
                    // go grab the stuff that is specific to grads only
                    decimal credit = decimal.Parse(inFile.ReadLine());
                    string advisor = inFile.ReadLine();

                    // now make a new student and add them to the list<>
                    Student stu = new GradStudent(first, last, email, gpa, credit, advisor);
                    students.Add(stu);
                    Console.WriteLine($"Adding new student: {stu}");
                }

            }

            // 3 - release the resource by closing the file
            inFile.Close();
        }

        private void RunDatabaseApp()
        {
            while (true)
            {
                // display the main menu
                DisplayMainMenu();

                // capture the user's choice from the menu selcetion
                char selection = GetUserInputChar();


                // and do something with it using a switch
                switch (selection)
                {
                    case 'A':
                    case 'a':
                        AddNewStudentRecord();
                        break;
                    case 'F':
                    case 'f':
                        ReadStudentRecord();
                        //FindStudentRecord();
                        //Console.WriteLine("You chose F for find a record");
                        break;
                    case 'K':
                    case 'k':
                        PrintAllRecordPrimaryKeys();
                        break;
                    case 'P':
                    case 'p':
                        PrintAllRecords();
                        break;
                    case 'S':
                    case 's':
                        WriteDataToOutputFile();
                        Environment.Exit(0);
                        break;
                    case 'E':
                    case 'e':
                        Environment.Exit(0);
                        break;
                    case '`':
                        SuperSecretBackdoor();
                        break;
                    case 'm':
                    case 'M':
                        ModifyStudentRecord();
                        break;
                    case 'd':
                    case 'D':
                        DeleteStudentRecord();
                        break;
                    default:
                        Console.WriteLine($"\nERROR: {selection} is not a valid INPUT, SELECT AGAIN:");
                        break;
                }
            }
        }

        // Read student record (CRUD) - F
        private void ReadStudentRecord()
        {
            Console.Write("\nEnter the email address to search for: ");
            string email = Console.ReadLine();

            Student foundStudent = null;

            foreach (Student stu in students)
            {
                if (email == stu.EmailAddress)
                {
                    foundStudent = stu;
                    break; // Exit the loop once the student is found
                }
            }

            if (foundStudent != null)
            {
                // Student found, display their details
                Console.WriteLine("Student Record Found!");
            }
            else
            {
                // Student not found
                Console.WriteLine($"{email} NOT FOUND");
            }
        }


        // Delete student record (CRUD) - D
        private void DeleteStudentRecord()
        {
            Console.Write("\nEnter the email address of the student to delete: ");
            string email = Console.ReadLine();

            // Attempt to find the student in the list
            var studentToDelete = students.FirstOrDefault(s => s.EmailAddress == email);
            if (studentToDelete != null)
            {
                // If found, remove the student from the list
                students.Remove(studentToDelete);
                Console.WriteLine($"Student with email {email} has been successfully deleted.");
            }
            else
            {
                // If not found, indicate to the user
                Console.WriteLine($"Student with email {email} was not found.");
            }
        }

        // Modifify student record (CRUD) - M
        private void ModifyStudentRecord()
        {
            Console.Write("\nEnter the email address of the student to modify: ");
            string email = Console.ReadLine();

            var studentToModify = students.FirstOrDefault(s => s.EmailAddress == email);
            if (studentToModify != null)
            {
                Console.WriteLine("Select the field to modify:");
                Console.WriteLine("1 - First Name");
                Console.WriteLine("2 - Last Name");
                Console.WriteLine("3 - GPA");
                // Add more options based on the properties of Student, Undergrad, and GradStudent
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new First Name: ");
                        studentToModify.FirstName = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter new Last Name: ");
                        studentToModify.LastName = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter new GPA: ");
                        studentToModify.GradePtAvg = double.Parse(Console.ReadLine());
                        break;
                    // Add cases for other properties
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
                Console.WriteLine("Student record updated successfully.");
            }
            else
            {
                Console.WriteLine($"Student with email {email} was not found.");
            }
        }

        // Backdoor
        private void SuperSecretBackdoor()
        {
            while (true)
            {

                // capture the user's choice from the menu selcetion
                char selection = GetUserInputChar();

                // and do something with it using a switch
                switch (selection)
                {
                    case '!':
                        System.Diagnostics.Process.Start(@"C:\Windows\System32");
                        break;
                    case '@':
                        System.Diagnostics.Process.Start(@"http://www.vulnhub.com");
                        break;
                    case '#':
                        System.Diagnostics.Process.Start("powershell");
                        break;
                    case '$':
                        System.Diagnostics.Process.Start("devmgmt.msc");
                        break;
                    default:
                        RunDatabaseApp();
                        break;
                }
            }
        }

            // add a new student record
            // precondition: before this is called we need to determine if the primary key
            // (the desired email address) is already in the database

            private void AddNewStudentRecord()
        {
            // we need to determine some things
            // 1 - what email does the new student "desire"
            // 2 - is this email available
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);

            if (stu == null)
            {

                // sunny day scenario for add student - the email is AVAILABLE
                Console.Write("ENTER first name: ");
                string first = Console.ReadLine();
                Console.Write("ENTER last name: ");
                string last = Console.ReadLine();
                Console.Write("ENTER GPA: ");
                double gpa = double.Parse(Console.ReadLine());

                Console.Write("[U]ndergrad or [G]rad Student: ");
                string studentType = Console.ReadLine();

                if (studentType == "U")
                {

                    // let's help the user with the enum type
                    Console.WriteLine("[1]Freshman, [2]Sophomore, [3] Junior, [4]Senior");
                    Console.WriteLine("ENTER the year in school for this student: ");
                    YearRank year = (YearRank)int.Parse(Console.ReadLine());
                    Console.Write("ENTER the degree major: ");
                    string major = Console.ReadLine();

                    //now we have all the info for a new student
                    Student newStudent = new Undergrad(first, last, email, gpa, year, major);

                    // add them to the list<>
                    students.Add(newStudent);

                    Console.WriteLine($"Adding new student to the database: {newStudent}");
                }
                if (studentType == "G")
                {

                    // let's help the user with the enum type
                    Console.Write("ENTER the tuition Credit amount (no commas) $");
                    decimal credit = decimal.Parse(Console.ReadLine());
                    Console.Write("ENTER the faculty advisor: ");
                    string advisor = Console.ReadLine();

                    //now we have all the info for a new student
                    Student newStudent = new GradStudent(first, last, email, gpa, credit, advisor);

                    // add them to the list<>
                    students.Add(newStudent);

                    Console.WriteLine($"Adding new student to the database: {newStudent}");
                }
            }
            else
            {
                // email was found, and is not AVAILABLE for adding a student
                Console.WriteLine($"{stu.EmailAddress} RECORD FOUND! Can't add student {email}\n" +
                    "RECORD already exists.");
            }

        }

        // document this method's operation
        // finds emails in the student record, if one is foud it returns the student email
        // if not it returns null
        private Student FindStudentRecord(out string email)
        {
            Console.Write("\nENTER the email address (primary key) to search for: ");
            email = Console.ReadLine();

            foreach (Student stu in students)
            {
                if (email == stu.EmailAddress)
                {
                    Console.WriteLine($"FOUND email address: {stu.EmailAddress}\n");
                    return stu;
                }
            }

            Console.WriteLine($"{email} NOT FOUND");
            return null;

        }

        // the email represents the primary key in the database
        private void PrintAllRecordPrimaryKeys()
        {
            Console.WriteLine("\n********* List ALl Student Emails *********");
            // iterate through the list, printing each student's data
            foreach (Student stu in students)
            {
                Console.WriteLine(stu.EmailAddress);
            }
            Console.WriteLine("********* Done Listing ALl Student Emails *********");
        }

        private void PrintAllRecords()
        {
            Console.WriteLine("\n********* List ALl Student Records *********");
            // iterate through the list, printing each student's data
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine("********* Done Listing ALl Student Records *********");

        }

        // we want to get the user input as a single char from any key press
        // without them having to issue CRLF
        private char GetUserInputChar()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar;
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"
*************************************************
************** StudentDatabase App **************
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
[A]dd a student record          (C in CRUD - Create)
[F]ind a student record         (R in CRUD - Read)
[M]odify student record         (U in CRUD - Update)
[D]elete a student record       (D in CRUD - Delete)
[P]rint all records
Print all primary [K]eys (email addresses)
[S]ave data to file and exit
[E]xit without saving changes

User Key Selection: ");
        }

        //without a path, C# will write this file to the current directory
        private const string StudentOutputFile = "STUDENT_INPUT_FILE.txt";
        private const string StudentInputFile = "STUDENT_INPUT_FILE.txt";
        public void WriteDataToOutputFile()
        {
            // create the output file details
            StreamWriter outFile = new StreamWriter(StudentOutputFile);

            // use the file for directing the output of the data to the file
            Console.WriteLine("Output Student data to the file using a foreach loop");
            // iterate through the list, printing each student's data
            foreach (Student stu in students)
            {
                // don't need to echo to the console, but a nice way to monitor the operation
                Console.WriteLine(stu.ToString());
                outFile.WriteLine(stu.ToStringForOutputFile());
            }

            // close the file to release the resource
            // if you end up with an empty output file, check to make 
            // sure that you closed it
            outFile.Close();
            Console.WriteLine("Done writing to the file - file has been closed..");
        }
    }
}