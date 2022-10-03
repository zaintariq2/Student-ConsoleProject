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
            /*Console.WriteLine("Enter Student Admission Date");
            s1.AdmissionDate = Console.ReadLine();
            Console.WriteLine("Enter Student Date of Birth");
            s1.DateOfBirth = Console.ReadLine();
            Console.WriteLine("Enter Student total subjects");
            s1.TotalSubjects = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Subjects");
            for (int i = 0; i<s1.TotalSubjects; i++)
            {
                s1.Subjects[i] = Console.ReadLine();
            }*/

            return s1;
        }
        public Student RequestStudentDataForEdit()
        {
            Student s1 = new Student();
            Console.WriteLine("\n----------Update Details---------");
            Console.WriteLine("Enter new Student Name");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Enter new Student Sur Name");
            s1.SurName = Console.ReadLine();
            Console.WriteLine("Enter new Student Program");
            s1.Program = Console.ReadLine();
            Console.WriteLine("Enter new Student Roll No");
            s1.RollNo = Console.ReadLine();
            Console.WriteLine("Enter new Student Fee");
            s1.Fee = Convert.ToInt32(Console.ReadLine());

            return s1;
        }
        public void RenderStudentDetails(Student s)
        {
            Console.WriteLine("\n--------Student details--------");
            Console.WriteLine($"Name of Student {s.Name}");
            Console.WriteLine($"SurName of Student {s.SurName}");
            Console.WriteLine($"Program of Student {s.Program}");
            Console.WriteLine($"Roll No of Student {s.RollNo}");
            Console.WriteLine($"Fee of Student {s.Fee}");
        }
        public void RenderStudentList (List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students in the list");
            }
            else
            {
                int i = 1;
                Console.WriteLine("\n-------Students Details -------");
                foreach (var student in students)
                {
                    Console.WriteLine($"\nDetail of Student {i}");
                    Console.WriteLine($"Name of Student {student.Name}");
                    Console.WriteLine($"SurName of Student {student.SurName}");
                    Console.WriteLine($"Program of Student {student.Program}");
                    Console.WriteLine($"Roll No of Student {student.RollNo}");
                    Console.WriteLine($"Fee of Student {student.Fee}");
                    i++;
                }
            }
        }
    }
}
