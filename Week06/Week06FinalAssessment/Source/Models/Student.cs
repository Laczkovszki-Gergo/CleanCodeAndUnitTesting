using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week06FinalAssessment.Source.Models
{
    public class Student : Person
    {
        string StudentNo { get; set; }
        DateTime RegistrationDate { get; set; }

        public Student()
        {

        }

        public Student(string fullName, DateTime birthDate, string address, string emailAddress, string studentNo, DateTime registrationDate)
            : base(fullName, birthDate, address, emailAddress)
        {
            StudentNo = studentNo;
            RegistrationDate = registrationDate;
        }
        public string GetStudentNo()
        {
            return StudentNo;
        }
        public DateTime GetRegistrationDate()
        {
            return RegistrationDate;
        }
    }
}
