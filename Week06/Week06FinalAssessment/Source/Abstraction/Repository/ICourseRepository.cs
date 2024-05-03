using System.Collections.Generic;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Abstraction.Repository
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task AddStudentToCourse(Student student, string courseName);
        Task<Course> GetCourseByName(string courseName);
        Task<IEnumerable<Course>> GetCourses();
        Task<CourseStatistic> GetCourseStatistics(string courseName);
    }
}
