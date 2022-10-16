using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Globalization;

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
            var std = Search(4, s.RollNo);  // 4 = Search by Roll No
            if (std==null)
            {
                allStudent.Add(s);
                SaveData(allStudent);
                Console.WriteLine("Data is Successfully Saved");
            }
            else
            {
                Console.WriteLine("\nStudent with this roll no already exists");
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
            found.Age = s.Age;
            found.AdmissionDate = s.AdmissionDate;
            found.DateOfBirth = s.DateOfBirth;
            SaveData(allStudent);
            Console.WriteLine("Your student record updated successfully:");
        }
        public List<Student> GetAll()
        {
            LoadData();
            return allStudent;
        }
        public Student Search(int searchBy, string input)
        {
            LoadData();
            var std = new Student();
            switch (searchBy)
            {
                case 1:  // Name
                    std = allStudent.FirstOrDefault(x => x.Name == input);
                    break;
                case 2:  // SurName
                    std = allStudent.FirstOrDefault(x => x.SurName == input);
                    break;
                case 3:  // Program
                    std = allStudent.FirstOrDefault(x => x.Program == input);
                    break;
                case 4:  // RollNo
                    std = allStudent.SingleOrDefault(x => x.RollNo == input);
                    break;
                case 5:  // Age
                    std = allStudent.FirstOrDefault(x => x.Age == Convert.ToInt32(input));
                    break;
                case 6:  // Fee
                    std = allStudent.FirstOrDefault(x => x.Fee == Convert.ToInt32(input));
                    break;
                case 7:  //Admission Date
                    std = allStudent.FirstOrDefault(x => x.AdmissionDate == Convert.ToDateTime(input));
                    break;
                case 8:  // Date of Birth
                    std = allStudent.FirstOrDefault(x => x.DateOfBirth == Convert.ToDateTime(input));
                    break;
                default:
                    break;
            }

            return std;
        }
        public List<Student> Sort(int sortBy, int sortInput)// returns sorted list based on field name in sortBy
        {
            LoadData();
            var std = new Student();
            switch(sortBy)
            {
                case 1:  // Name
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.Name.CompareTo(y.Name));
                    }
                    else // Desc
                    {
                        allStudent.Sort((x, y) => y.Name.CompareTo(x.Name));
                    }
                    break;
                case 2:  // SurName
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.SurName.CompareTo(y.SurName));
                    }
                    else  // Desc
                    {
                        allStudent.Sort((x, y) => y.SurName.CompareTo(x.SurName));
                    }
                    break;
                case 3:  // Program
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.Program.CompareTo(y.Program));
                    }
                    else   // Desc
                    {
                        allStudent.Sort((x, y) => y.Program.CompareTo(x.Program));
                    }
                    break;
                case 4:  // RollNo
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.RollNo.CompareTo(y.RollNo));
                    }
                    else   // Desc
                    {
                        allStudent.Sort((x, y) => y.RollNo.CompareTo(x.RollNo));
                    }
                    break;
                case 5:  // Age
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.Age.CompareTo(y.Age));
                    }
                    else   // Desc
                    {
                        allStudent.Sort((x, y) => y.Age.CompareTo(x.Age));
                    }
                    break;
                case 6:  // Fee
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.Fee.CompareTo(y.Fee));
                    }
                    else   // Desc
                    {
                        allStudent.Sort((x, y) => y.Fee.CompareTo(x.Fee));
                    }
                    break;
                case 7:  //Admission Date
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.AdmissionDate.CompareTo(y.AdmissionDate));
                    }
                    else   // Desc
                    {
                        allStudent.Sort((x, y) => y.AdmissionDate.CompareTo(x.AdmissionDate));
                    }
                    break;
                case 8:  // Date of Birth
                    if (sortInput == 1)  // Asce
                    {
                        allStudent.Sort((x, y) => x.DateOfBirth.CompareTo(y.DateOfBirth));
                    }
                    else  // Desc
                    {
                        allStudent.Sort((x, y) => y.DateOfBirth.CompareTo(x.DateOfBirth));
                    }
                    break;
                default:
                    break;
            }
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
        }
    }
}
