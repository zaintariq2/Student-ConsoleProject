using System;
using System.Linq;
using System.Collections.Generic;

namespace testproject
{
    enum CommandType
    {
        Create = 1, //1
        ShowDetail, //2
        Edit,       //3
        List,       //4
        Search,     //5
        Delete,     //6
        Exit        //7
    }
    class Command
    {
        public enum type { Create, ShowDetail, Edit, List, Search, Delete, Exit };
    }
    class ListCommand:Command
    {
        //string sortBy[ame, age, rollNo...]
    }
    class Program
    {
        static void Main(string[] args)
        {
            Controller c1 = new Controller();
            c1.Loop();
        }
    }
}
