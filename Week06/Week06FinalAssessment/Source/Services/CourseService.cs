using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Repository;
using Week06FinalAssessment.Source.Abstraction.Services;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository CourseRepository;
        private readonly IPaymentService PaymentService;
        private readonly INotificationService NotificationService;

        public CourseService(ICourseRepository courseRepository, IPaymentService paymentService, INotificationService notificationService)
        {
            CourseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            PaymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            NotificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public async Task AddCourse(Course course)
        {
            await CourseRepository.AddCourse(course);
        }
        public async Task<Course> GetCourseByName(string courseName)
        {
            return await CourseRepository.GetCourseByName(courseName);
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await CourseRepository.GetCourses();
        }
        public async Task AddStudentToCourse(Student student, string courseName)
        {
            Course course = await CourseRepository.GetCourseByName(courseName);
            if (course == null)            
                throw new Exception("Course not found");            

            var isCoursePayedByStudent = await PaymentService.GetIsOrderPayed(student,course);
            if (!isCoursePayedByStudent)            
                throw new Exception("Course is not yet paid by Student.");            

            course.AddStudent(student);
            await NotificationService.SendNotifications($"{student.GetFullName()} student was added to course.");
        }

        public async Task<CourseStatistic> GetCourseStatistics(string courseName)
        {
            return await CourseRepository.GetCourseStatistics(courseName);
        }
    }
}
