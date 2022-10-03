using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (cmd == 8)
                    {
                        break;
                    }
                    this.ProcessCommand(cmd);
                }
                catch
                {
                    Console.WriteLine("Please Enter Correct input:");
                    continue;
                }
                if (cmd != 8)
                {
                    Console.ReadKey();
                }
                Console.Clear();
            } while (cmd != 8);
        }
        public void ProcessCommand(int cmd)
        {
            if (cmd > 0 && cmd < 9)
            {
                switch (cmd)
                {
                    case 1:  // Add
                        var std = _uiBuilder.RequestStudentDataForCreate();
                        _modelRepository.AddNew(std);
                        break;
                    case 2:  // ShowDetail
                        Console.WriteLine("\nEnter the roll no of the student you want to view:");
                        string showrollno = Console.ReadLine();
                        var showdetail = _modelRepository.SearchByRollNo(showrollno);
                        if (showdetail != null)
                        {
                            _uiBuilder.RenderStudentDetails(showdetail);
                        }
                        else
                        {
                            Console.WriteLine("\nThere is no student with this Roll No:");
                        }
                        break;
                    case 3:  // Edit
                        Console.WriteLine("\nEnter the roll no of the student you want to edit:");
                        string editrollno = Console.ReadLine();
                        var stdExist = _modelRepository.SearchByRollNo(editrollno);
                        if (stdExist != null)
                        {
                            var updatedDetails = _uiBuilder.RequestStudentDataForEdit();
                            _modelRepository.Update(updatedDetails, editrollno);
                        }
                        else
                        {
                            Console.WriteLine("\nThere is no student with this Roll No:");
                        }
                        break;
                    case 4:  // List
                        var students = _modelRepository.GetAll();
                        _uiBuilder.RenderStudentList(students);
                        break;
                    case 5:  //Search
                        Console.WriteLine("\n--------Search by Roll No --------");
                        Console.WriteLine("Enter the Roll No of the student");
                        string roll = Console.ReadLine();
                        var searchStudent = _modelRepository.SearchByRollNo(roll);
                        if (searchStudent != null)
                        {
                            _uiBuilder.RenderStudentDetails(searchStudent);
                        }
                        else
                        {
                            Console.WriteLine("\nThere is no student with this Roll No:");
                        }
                        break;
                    case 6:  // Delete
                        Console.WriteLine("\nEnter the roll no of the student you want to delete:");
                        string deleterollno = Console.ReadLine();
                        _modelRepository.Delete(deleterollno);
                        break;
                    case 7:  // Sorted List
                        
                        var allItems = _modelRepository.GetAll();
                        var sorteditems = _modelRepository.SortByRollNo(allItems);
                        if (sorteditems.Count==0)
                        {
                            Console.WriteLine("\nThere is no student in the list:");
                        }
                        else
                        {
                            Console.WriteLine("\n-------Sort By Roll No--------");
                            _uiBuilder.RenderStudentList(sorteditems);
                        }
                        break;
                    case 8:  // Exit
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correct input:");
            }
        }
    }
}
