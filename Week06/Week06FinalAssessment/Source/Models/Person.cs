using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Models
{
    public abstract class Person
    {
        string FullName;
        DateTime BirthDate;
        string Address;
        string EmailAddress;

        protected Person()
        {

        }
        protected Person(string fullName, DateTime birthDate, string address, string emailAddress)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
            EmailAddress = emailAddress;
        }
        public string GetFullName()
        {
            return FullName;
        }
        public DateTime GetBirthDate() 
        {
            return BirthDate;
        }
        public string GetAddress()
        {
            return Address;
        }
        public string GetEmailAddress() 
        {
            return EmailAddress;
        }
    }
}
