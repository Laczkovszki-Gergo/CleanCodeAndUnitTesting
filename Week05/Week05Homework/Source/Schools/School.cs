using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Schools
{
    public class School
    {
        private List<SchoolClass> classes = new List<SchoolClass>();

        public School() { }

        public void AddClass(SchoolClass schoolClass)
        {
            classes.Add(schoolClass);
        }

        public int GetStudentCount()
        {
            int totalStudents = 0;
            foreach (var schoolClass in classes)
            {
                totalStudents += schoolClass.GetStudentCount();
            }
            return totalStudents;
        }
    }
}
