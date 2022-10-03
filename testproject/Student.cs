using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproject
{
    class Student
    {
        private string _name, _surName, _program, _rollNo;
        private int _fee, _totalSubjects;
        private string _admissionDate;
        private string _dateOfBirth;
        private string[] _subjects;
        public string Name { get { return _name; } set { _name = value; } }
        public string SurName { get { return _surName; } set { _surName = value; } }
        public string Program { get { return _program; } set { _program = value; } }
        public string RollNo { get { return _rollNo; } set { _rollNo = value; } }
        public int Fee { get { return _fee; } set { _fee = value; } }
        public string AdmissionDate { get { return _admissionDate; } set { _admissionDate = value; } }
        public string DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public int TotalSubjects { get { return _totalSubjects; } set { _totalSubjects = value; } }
        public string[] Subjects { get { return _subjects; } set { _subjects = value; } }
    }
}
