using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Abstraction.Clients
{
    public interface IDbClient
    {
        Task SaveCourse(Course course);
        Task<Course> GetCourseByName(string courseName);
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
