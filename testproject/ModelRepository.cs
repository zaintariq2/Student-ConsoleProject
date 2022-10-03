using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproject
{
    class ModelRepository
    {
        public List<Student> allStudent = new List<Student>();
        public void AddNew(Student s)
        {
            allStudent.Add(s);
            Console.WriteLine("Data is Saved");
        }
        public void Update(Student s, string roll)
        {
            var found = allStudent.FirstOrDefault(c => c.RollNo == roll);
            found.Name = s.Name;
            found.SurName = s.SurName;
            found.RollNo = s.RollNo;
            found.Program = s.Program;
            found.Fee = s.Fee;
            Console.WriteLine("Your student record updated successfully:");
        }
        public List<Student> GetAll()
        {
            return allStudent;
        }
        public Student SearchByRollNo(string roll)
        {
            var std = new Student();
            if (allStudent.Count != 0)
            {
                foreach (var student in allStudent)
                {
                    if (roll == student.RollNo)
                    {
                        std = student;
                        break;
                    }
                    else
                    {
                        std = null;
                    }
                }
            }
            else
            {
                std = null;
            }
            return std;
        }
        public List<Student> SortByRollNo(List<Student> itemsToSort)// returns sorted list based on field name in sortBy
        {
            allStudent.Sort((x, y) => x.RollNo.CompareTo(y.RollNo));
            return allStudent;
        }
        public void Delete(string roll)
        {
            var item = allStudent.SingleOrDefault(x => x.RollNo == roll);
            if (item != null)
            {
                allStudent.Remove(item);
                Console.WriteLine("The student record is deleted successfully:");
            }
            else
            {
                Console.WriteLine("\nThere is no student with this Roll No:");
            }
        }
        //public List<Student> FilterBy(string filterByField, string query, List<Student> itemsToFilterFrom);// returns sorted list based on field name in sortBy
        //private LoadData();
        //private SaveData();
    }
}
