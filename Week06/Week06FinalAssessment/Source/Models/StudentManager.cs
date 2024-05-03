using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Models
{
    public class StudentManager
    {
        private readonly List<Student> Students = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public int GetStudentsCount()
        {
            return Students.Count;
        }

        public List<Student> GetStudents() 
        {
            return Students;
        }
    }
}
