using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace testproject
{
    class ModelRepository
    {
        public List<Student> allStudent = new List<Student>();
        public void StartApp()  // Run every time when program is start
        {
            LoadData();
        }
        public void AddNew(Student s)
        {
            LoadData();
            var std = SearchByRollNo(s.RollNo);
            if (std==null)
            {
                allStudent.Add(s);
                SaveData(allStudent);
            }
            else
            {
                Console.WriteLine("Student with this roll no already exists");
            }
        }
        public void Update(Student s, string roll)
        {
            LoadData();
            var found = allStudent.FirstOrDefault(c => c.RollNo == roll);
            found.Name = s.Name;
            found.SurName = s.SurName;
            found.RollNo = s.RollNo;
            found.Program = s.Program;
            found.Fee = s.Fee;
            Console.WriteLine("Your student record updated successfully:");
            SaveData(allStudent);
        }
        public List<Student> GetAll()
        {
            LoadData();
            return allStudent;
        }
        public Student SearchByRollNo(string roll)
        {
            LoadData();
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
            LoadData();
            allStudent.Sort((x, y) => x.RollNo.CompareTo(y.RollNo));
            return allStudent;
        }
        public void Delete(string roll)
        {
            LoadData();
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
            SaveData(allStudent);
        }
        private void LoadData()
        {
            var jsonStr = File.ReadAllText("Student.proj");
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonStr);

            allStudent = studentList;
        }
        private void SaveData(List<Student> stdList)
        {
            string fileName = "Student.proj";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonConvert.SerializeObject(stdList, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Data is Successfully Saved");
        }
    }
}
