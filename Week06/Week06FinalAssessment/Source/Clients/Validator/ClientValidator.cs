using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Clients.Validator
{
    public static class ClientValidator
    {
        internal static void ValidateFinancialApiArguments(Student student, Course course, string errorMessagePrefix)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), $"{errorMessagePrefix}: Student cannot be null.");
            if (course == null)
                throw new ArgumentNullException(nameof(course), $"{errorMessagePrefix}: Course cannot be null.");
        }

        internal static void ValidateNotificationMessage(string notificationMessage)
        {
            if (string.IsNullOrEmpty(notificationMessage))
                throw new ArgumentNullException(nameof(notificationMessage), "Notification message cannot be null or empty.");
        }

        internal static void ValidateCourseArgument(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
        }

        internal static void ValidateCourseNameArgument(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
                throw new ArgumentNullException(nameof(courseName), "Course name cannot be null or empty.");
        }
    }
}
