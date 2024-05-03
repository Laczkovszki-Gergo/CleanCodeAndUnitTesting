using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Models
{
    public class Course
    {
        private readonly StudentManager StudentManager;
        private Lecturer Lecturer;
        private string CourseName;
        private DateTime StartDate;
        private int LengthInWeeks;
        private decimal CostInHuf;
        private int LecturesCompleted;
        private DateTime LastAccesed;

        public Course() { }

        public Course(Lecturer lecturer,string courseName, DateTime startDate, int lengthInWeeks, decimal costInHuf)
        {
            Lecturer = lecturer;
            CourseName = courseName;
            StartDate = startDate;
            LengthInWeeks = lengthInWeeks;
            CostInHuf = costInHuf;
            LecturesCompleted = 0;
            LastAccesed = default;
            StudentManager = new StudentManager();
        }

        public void AddStudent(Student student)
        {
            LastAccesed = DateTime.Now;
            StudentManager.AddStudent(student);
        }
        public string GetCourseName()
        {
            LastAccesed = DateTime.Now;
            return CourseName;
        }
        public int GetLenghtInWeeks()
        {
            LastAccesed = DateTime.Now;
            return LengthInWeeks;
        }
        public int GetStudentsCountOfCourse()
        {
            LastAccesed = DateTime.Now;
            return StudentManager.GetStudentsCount();
        }
        public List<Student> GetStudents()
        {
            LastAccesed = DateTime.Now;
            return StudentManager.GetStudents();
        }
        public int GetCompledtedLecturesCount()
        {
            LastAccesed = DateTime.Now;
            return LecturesCompleted;
        }
        public void CompleteLecture()
        {
            LastAccesed = DateTime.Now;
            LecturesCompleted++;
        }
        public double GetProgress()
        {
            LastAccesed = DateTime.Now;
            return (double)(((double)LecturesCompleted / (double)LengthInWeeks) * 100);
        }
        public DateTime GetLastAccesed()
        {
            return LastAccesed;
        }
    }
}
