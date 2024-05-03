using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Clients.Validator;
using Week06FinalAssessment.Source.Exceptions;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Clients
{
    public class DbClient : IDbClient
    {
        private Dictionary<string, Course> Courses;

        public DbClient()
        {
            Courses = new Dictionary<string, Course>();
        }

        public async Task SaveCourse(Course course)
        {
            try
            {
                ClientValidator.ValidateCourseArgument(course);        

                Courses[course.GetCourseName()] = course;
            }
            catch (DbClientException ex) when (ex is DbClientException)
            {
                throw new DbClientException("Error occurred while saving the course: " + ex.Message, ex);
            }
            catch (ArgumentNullException ex) when (ex is ArgumentNullException)
            {
                throw new ArgumentNullException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown error occured during saving course: " + ex.Message,ex);
            }
        }

        public async Task<Course> GetCourseByName(string courseName)
        {
            try
            {
                ClientValidator.ValidateCourseNameArgument(courseName);

                if (!Courses.TryGetValue(courseName, out var course))                
                    throw new KeyNotFoundException($"Course '{courseName}' not found.");             
                return course;
            }
            catch (DbClientException ex) when (ex is DbClientException)
            {
                throw new DbClientException("Error occurred while getting the course by name: " + ex.Message, ex);
            }
            catch (KeyNotFoundException ex) when (ex is KeyNotFoundException)
            {
                throw new KeyNotFoundException(ex.Message, ex);
            }
            catch (ArgumentNullException ex) when (ex is ArgumentNullException)
            {
                throw new ArgumentNullException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown error occurred while getting the course by name: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            try
            {
                return Courses.Values;
            }
            catch (DbClientException ex) when (ex is DbClientException)
            {
                throw new DbClientException("Error occurred while getting all courses: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown error occurred while getting all courses: " + ex.Message, ex);
            }
        }
    }
}
