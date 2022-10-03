using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproject
{
    class UIBuilder
    {
        public int RenderMenu()
        {
            int operation;
            string userInput;
            int value;
            Console.WriteLine("1-Add, 2-ShowDetail, 3-Edit, 4-List, 5-Search, 6-Delete, 7-SortList 8-Exit");
            userInput = Console.ReadLine();
            if (int.TryParse(userInput, out value))
            {
                operation = value;
            }
            else
            {
                operation = 0;
            }
            return operation;
        }
        public Student RequestStudentDataForCreate()
        {
            Student s1 = new Student();
            Console.WriteLine("\n---------Student Detail---------");
            Console.WriteLine("Enter Student Name");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Enter Student Sur Name");
            s1.SurName = Console.ReadLine();
            Console.WriteLine("Enter Student Program");
            s1.Program = Console.ReadLine();
            Console.WriteLine("Enter Student Roll No");
            s1.RollNo = Console.ReadLine();
            Console.WriteLine("Enter Student Fee");
            s1.Fee = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Age");
            s1.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Admission Date (format: DD/MM/YYYY)");
            s1.AdmissionDate = Console.ReadLine();
            Console.WriteLine("Enter Student Date of Birth (format: DD/MM/YYYY)");
            s1.DateOfBirth = Console.ReadLine();

            return s1;
        }
        public Student RequestStudentDataForEdit()
        {
            Student s1 = new Student();
            Console.WriteLine("\n----------Update Details---------");
            Console.WriteLine("Enter Student new Name");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Enter Student new SurName");
            s1.SurName = Console.ReadLine();
            Console.WriteLine("Enter Student new Program");
            s1.Program = Console.ReadLine();
            Console.WriteLine("Enter Student new Roll No");
            s1.RollNo = Console.ReadLine();
            Console.WriteLine("Enter Student new Fee");
            s1.Fee = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student new Age");
            s1.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student new Admission Date (format: DD/MM/YYYY)");
            s1.AdmissionDate = Console.ReadLine();
            Console.WriteLine("Enter Student new Date of Birth (format: DD/MM/YYYY)");
            s1.DateOfBirth = Console.ReadLine();

            return s1;
        }
        public void RenderStudentDetails(Student s)
        {
            Console.WriteLine("\n--------Student details--------\t");
            Console.WriteLine($"--------------------------------+");
            Console.WriteLine($"Name\t\t| {s.Name}\t\t|");
            Console.WriteLine($"SurName\t\t| {s.SurName}\t\t|");
            Console.WriteLine($"Program\t\t| {s.Program}\t\t|");
            Console.WriteLine($"Roll No\t\t| {s.RollNo}\t\t|");
            Console.WriteLine($"Fee\t\t| {s.Fee}\t\t|");
            Console.WriteLine($"Age\t\t| {s.Age}\t\t|");
            Console.WriteLine($"Admission Date\t| {s.AdmissionDate}\t|");
            Console.WriteLine($"Date of Birth\t| {s.DateOfBirth}\t|");
            Console.WriteLine($"--------------------------------+");
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
                Console.WriteLine("\n-------Students Details -------");
                foreach (var student in students)
                {
                    Console.WriteLine($"\n--------------------------------+");
                    Console.WriteLine($"Detail of Student: {i}\t\t|");
                    Console.WriteLine($"--------------------------------+");
                    Console.WriteLine($"Name\t\t| {student.Name}\t\t|");
                    Console.WriteLine($"SurName\t\t| {student.SurName}\t\t|");
                    Console.WriteLine($"Program\t\t| {student.Program}\t\t|");
                    Console.WriteLine($"Roll No\t\t| {student.RollNo}\t\t|");
                    Console.WriteLine($"Fee\t\t| {student.Fee}\t\t|");
                    Console.WriteLine($"Age\t\t| {student.Age}\t\t|");
                    Console.WriteLine($"Admission Date\t| {student.AdmissionDate}\t|");
                    Console.WriteLine($"Date of Birth\t| {student.DateOfBirth}\t|");
                    Console.WriteLine($"--------------------------------+");
                    i++;
                }
            }
        }
    }
}
