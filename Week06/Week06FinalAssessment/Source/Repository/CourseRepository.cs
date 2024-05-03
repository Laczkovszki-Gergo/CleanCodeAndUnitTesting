using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Abstraction.Repository;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private IDbClient DbClient;

        public CourseRepository(IDbClient dbClient)
        {
            DbClient = dbClient;
        }

        public async Task AddCourse(Course course)
        {
            await DbClient.SaveCourse(course);
        }
        public async Task AddStudentToCourse(Student student, string courseName)
        {
            var course = await DbClient.GetCourseByName(courseName);
            if (course != null)
            {
                course.AddStudent(student);
                await DbClient.SaveCourse(course);
            }
            else            
                throw new InvalidOperationException($"Course '{courseName}' not found.");
            
        }
        public async Task<Course> GetCourseByName(string courseName)
        {
            return await DbClient.GetCourseByName(courseName);
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await DbClient.GetAllCourses();
        }
        public async Task<CourseStatistic> GetCourseStatistics(string courseName)
        {
            // Lekérdezzük a tanfolyamot a név alapján
            var course = await DbClient.GetCourseByName(courseName);
            if (course != null)
            {
                var statistic = new CourseStatistic(course);
                return statistic;
            }
            else
            {
                throw new InvalidOperationException($"Course '{courseName}' not found.");
            }
        }
    }
}
