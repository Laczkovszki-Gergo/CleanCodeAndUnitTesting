using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Repository;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Source.Abstraction.Services
{
    public interface ICourseService
    {
        Task AddCourse(Course course);
        Task<Course> GetCourseByName(string courseName);
        Task<IEnumerable<Course>> GetCourses();
        Task AddStudentToCourse(Student student, string courseName);
        Task<CourseStatistic> GetCourseStatistics(string courseName);
    }
}
