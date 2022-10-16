using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace testproject
{
    class Controller
    {
        UIBuilder _uiBuilder = new UIBuilder();
        ModelRepository _modelRepository = new ModelRepository();

        public void Loop()
        {
            int cmd;
            _modelRepository.StartApp();
            do
            {
                cmd = _uiBuilder.RenderMenu();
                try
                {
                    if (cmd == 7)
                    {
                        break;
                    }
                    this.ProcessCommand(cmd);
                }
                catch
                {
                    Console.WriteLine("Invalid Input:");
                    continue;
                }
                if (cmd != 7)
                {
                    Console.ReadKey();
                }
                Console.Clear();
            } while (cmd != 8);
        }
        public void ProcessCommand(int cmd)
        {
            switch (cmd)
            {
                case 1:  // Add
                    var std = _uiBuilder.RequestStudentDataForCreate();
                    _modelRepository.AddNew(std);
                    break;
                case 2:  // Search
                    Console.WriteLine("How would you like to search by:");
                    var searchStudent = SearchBy();
                    if (searchStudent != null)
                    {
                        _uiBuilder.RenderStudentDetails(searchStudent);
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no student with these details:");
                    }
                    break;
                case 3:  // Edit
                    Console.WriteLine("How would you like to edit by:");
                    var editStudent = SearchBy();

                    if (editStudent != null)
                    {
                        _uiBuilder.RenderStudentDetails(editStudent);
                        var updatedDetails = _uiBuilder.RequestStudentDataForEdit();
                        _modelRepository.Update(updatedDetails, editStudent.RollNo);
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no student with these details:");
                    }
                    break;
                case 4:  // List
                    var students = _modelRepository.GetAll();
                    _uiBuilder.RenderStudentList(students);
                    break;
                case 5:  // Delete
                    Console.WriteLine("How would you like to delete by:");
                    var deleteStudent = SearchBy();
                    if (deleteStudent != null)
                    {
                        _uiBuilder.RenderStudentDetails(deleteStudent);

                        Console.WriteLine("Are you sure you want to delete this record;");
                        Console.WriteLine("Enter y/n");
                        string userInput = Console.ReadLine();

                        if (userInput == "y" || userInput == "Y")
                        {
                            _modelRepository.Delete(deleteStudent.RollNo);
                        }
                        else if (userInput == "n" || userInput == "N")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is no student with these details:");
                    }
                    
                    break;
                case 6:  // Sorted List
                    Console.WriteLine("How would you like to sort by:");
                    var sortBy = _uiBuilder.GetInput();         // Sort By
                    var sortInput = _uiBuilder.GetSortInput();        // Asce or Desc
                    var sorteditems = _modelRepository.Sort(sortBy, sortInput);

                    if (sorteditems.Count == 0)
                    {
                        Console.WriteLine("\nThere is no student in the list:");
                    }
                    else
                    {
                        Console.WriteLine("\n-------Sort List--------");
                        _uiBuilder.RenderStudentList(sorteditems);
                    }
                    break;
                case 7:  // Exit
                    break;
                default:
                    break;
            }
        }
        public Student SearchBy()
        {
            int input = _uiBuilder.GetInput();
            Student searchStudent = new Student();
            switch (input)
            {
                case 1:  // Name
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetName());
                    break;
                case 2:  // SurName
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetSurName());
                    break;
                case 3:  // Program
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetProgram());
                    break;
                case 4:  // RollNo
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetRollNo());
                    break;
                case 5:  // Age
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetAge().ToString());
                    break;
                case 6:  // Fee
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetFee().ToString());
                    break;
                case 7:  //Admission Date
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetAdmissionDate().ToString());
                    break;
                case 8:  // Date of Birth
                    searchStudent = _modelRepository.Search(input, _uiBuilder.GetDateOfBirth().ToString());
                    break;
                default:
                    break;
            }
            return searchStudent;
        }
    }
}
