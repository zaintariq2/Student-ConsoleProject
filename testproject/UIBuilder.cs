using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace testproject
{
    class UIBuilder
    {
        public int IntValidation(string input)
        {
            int value, a;
            if (int.TryParse(input, out value))
            {
                a = value;
            }
            else
            {
                a = 0;
            }
            return a;
        }
        public DateTime DateValidation()
        {
            DateTime d;
            DateTime newDate = new DateTime();
            bool dateValid;
            do
            {
                Console.WriteLine("Enter the Date: ");
                string input = Console.ReadLine();
                dateValid = DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
                if (dateValid)
                {
                    newDate = d.Date;
                }
                else
                {
                    Console.WriteLine("Invalid Date Format!");
                }
            } while (!dateValid);

            return newDate;
        }
        public string StringValidation(string input)
        {
            string value = null;
            if (Regex.Match(input, "^[A-Z][a-zA-Z]*$").Success)
            {
                value = input;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            return value;
        }
        public int RenderMenu()
        {
            int operation;
            do
            {
                Console.WriteLine("1-Add, 2-Search, 3-Edit, 4-List, 5-Delete, 6-SortList 7-Exit");
                operation = IntValidation(Console.ReadLine());
                if (operation < 1 || operation > 7)
                {
                    operation = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (operation == 0);

            return operation;
        }
        public Student RequestStudentDataForCreate()
        {
            Student s1 = new Student();
            Console.WriteLine("\n---------Student Detail---------");
            do
            {
                Console.WriteLine("Enter Student Name");
                s1.Name = StringValidation(Console.ReadLine());
            } while (s1.Name == null);
            do
            {
                Console.WriteLine("Enter Student SurName");
                s1.SurName = StringValidation(Console.ReadLine());
            } while (s1.Name == null);
            
            Console.WriteLine("Enter Student Program");
            s1.Program = Console.ReadLine();
            Console.WriteLine("Enter Student Roll No");
            s1.RollNo = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter Student Fee (1 to 250000)");
                s1.Fee = IntValidation(Console.ReadLine());
                if (s1.Fee < 1 || s1.Fee > 250000)
                {
                    s1.Fee = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (s1.Fee == 0);

            do
            {
                Console.WriteLine("Enter Student Age (18 to 40)");
                s1.Age = IntValidation(Console.ReadLine());
                if (s1.Age < 18 || s1.Age > 40)
                {
                    s1.Age = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (s1.Age == 0);

            Console.WriteLine("Enter Student Admission Date (MM/dd/yyyy)");
            s1.AdmissionDate = DateValidation();

            Console.WriteLine("Enter Student Date of Birth (MM/dd/yyyy)");
            s1.DateOfBirth = DateValidation();

            return s1;
        }
        public Student RequestStudentDataForEdit()
        {
            Student s1 = new Student();
            Console.WriteLine("\n----------Update Details---------");
            do
            {
                Console.WriteLine("Enter Student new Name");
                s1.Name = StringValidation(Console.ReadLine());
            } while (s1.Name == null);
            do
            {
                Console.WriteLine("Enter Student new SurName");
                s1.SurName = StringValidation(Console.ReadLine());
            } while (s1.Name == null);

            Console.WriteLine("Enter Student new Program");
            s1.Program = Console.ReadLine();
            Console.WriteLine("Enter Student new Roll No");
            s1.RollNo = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter Student new Fee (1 to 250000)");
                s1.Fee = IntValidation(Console.ReadLine());
                if (s1.Fee < 1 || s1.Fee > 250000)
                {
                    s1.Fee = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (s1.Fee == 0);

            do
            {
                Console.WriteLine("Enter Student new Age (18 to 40)");
                s1.Age = IntValidation(Console.ReadLine());
                if (s1.Age < 18 || s1.Age > 40)
                {
                    s1.Age = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (s1.Age == 0);

            Console.WriteLine("Enter Student new Admission Date (MM/dd/yyyy)");
            s1.AdmissionDate = DateValidation();

            Console.WriteLine("Enter Student new Date of Birth (MM/dd/yyyy)");
            s1.DateOfBirth = DateValidation();

            return s1;
        }
        public void RenderStudentDetails(Student s)
        {
            ConsoleTable table1 = new ConsoleTable();

            Console.WriteLine("\n--------Student details--------\t");
            table1.PrintLine();
            table1.PrintRow("Name", "SurName", "Program", "Roll No", "Fee", "Age", "Admission Date", "Date of Birth");
            table1.PrintLine();
            table1.PrintRow(s.Name, s.SurName, s.Program, s.RollNo, s.Fee.ToString(), s.Age.ToString(), s.AdmissionDate.ToString(), s.DateOfBirth.ToString());
            table1.PrintLine();
        }
        public void RenderStudentList (List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nThere are no students in the list");
            }
            else
            {
                int i = 1;
                ConsoleTable table1 = new ConsoleTable();
                Console.WriteLine("\n-------Students Details -------");
                table1.PrintLine();
                table1.PrintRow("ID", "Name", "SurName", "Program", "Roll No", "Fee", "Age", "Admission Date", "Date of Birth");
                table1.PrintLine();
                foreach (var student in students)
                {   
                    table1.PrintRow(i.ToString(), student.Name, student.SurName, student.Program, student.RollNo, student.Fee.ToString(), student.Age.ToString(), student.AdmissionDate.ToString(), student.DateOfBirth.ToString());
                    table1.PrintLine();

                    i++;
                }
            }
        }
        public int GetSortInput()
        {
            int userInput;
            do
            {
                Console.WriteLine("Enter 1 for Ascending and 2 for descending:");
                userInput = IntValidation(Console.ReadLine());
                if (userInput != 1 && userInput != 2)
                {
                    userInput = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (userInput == 0);

            return userInput;
        }
        public int GetInput()
        {
            int userInput;
            do
            {
                Console.WriteLine("1-By Name, 2-By SurName, 3-By Program, 4-By RollNo, 5-By Age, 6-By Fee, 7-By Admission Date, 8-By Date of Birth");
                userInput = IntValidation(Console.ReadLine());
                if (userInput < 1 || userInput > 8)
                {
                    userInput = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (userInput == 0);

            return userInput;
        }
        public string GetName()
        {
            string id;
            Console.WriteLine("Enter the Name: ");
            id = Console.ReadLine();

            return id;
        }
        public string GetSurName()
        {
            string id;
            Console.WriteLine("Enter the SurName: ");
            id = Console.ReadLine();

            return id;
        }
        public string GetProgram()
        {
            string id;
            Console.WriteLine("Enter the Program: ");
            id = Console.ReadLine();

            return id;
        }
        public string GetRollNo()
        {
            string id;
            Console.WriteLine("Enter the Roll No: ");
            id = Console.ReadLine();

            return id;
        }
        public int GetAge()
        {
            int id;
            do
            {
                Console.WriteLine("Enter the Age (18 to 40): ");
                id = IntValidation(Console.ReadLine());
                if (id < 18 || id > 40)
                {
                    id = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (id == 0);

            return id;
        }
        public int GetFee()
        {
            int id;
            do
            {
                Console.WriteLine("Enter the Fee (1 to 250000): ");
                id = IntValidation(Console.ReadLine());
                if (id < 1 || id > 250000)
                {
                    id = 0;
                    Console.WriteLine("Invalid Input! ");
                }
            } while (id == 0);

            return id;
        }
        public DateTime GetAdmissionDate()
        {
            DateTime id;
            Console.WriteLine("Enter the Admission Date (MM/dd/yyyy) ");
            id = DateValidation();

            return id;
        }
        public DateTime GetDateOfBirth()
        {
            DateTime id;
            Console.WriteLine("Enter the Date of Birth (MM/dd/yyyy) ");
            id = DateValidation();

            return id;
        }
    }
}
