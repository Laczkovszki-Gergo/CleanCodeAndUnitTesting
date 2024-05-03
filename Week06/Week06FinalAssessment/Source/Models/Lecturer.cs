using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Models
{
    public class Lecturer : Person
    {
        string LecturerNo { get; set; }

        public Lecturer() { }

        public Lecturer(string fullName, DateTime birthDate, string address, string emailAddress, string lecturerNo)
            : base(fullName, birthDate, address, emailAddress)
        {
            LecturerNo = lecturerNo;
        }
        public string GetLecturerNo()
        {
            return LecturerNo;
        }
    }
}
