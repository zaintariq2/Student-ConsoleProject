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
    class Program
    {
        static void Main(string[] args)
        {
            Controller c1 = new Controller();
            c1.Loop();
        }
    }
}
