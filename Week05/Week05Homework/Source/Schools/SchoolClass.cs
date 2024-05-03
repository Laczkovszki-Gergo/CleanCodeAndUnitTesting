using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week05Homework.Source.Schools
{
    public interface ISchoolClass
    {
        void AddStudent(Student student);
        int GetStudentCount();

    }

    public class SchoolClass : ISchoolClass
    {
        private List<Student> students = new List<Student>();

        public SchoolClass() { }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public int GetStudentCount()
        {
            return this.students.Count;
        }
    }
}
