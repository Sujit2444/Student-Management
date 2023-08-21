using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double? CGPA { get; set; }

        public string Departemnt { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Birthdate { get; set; }
    }
}
