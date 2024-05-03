using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Models
{
    public class CourseStatistic
    {
        Course Course;
        public CourseStatistic() { }
        public CourseStatistic(Course course)
        {
            Course = course;
        }

        public string GetStatisticOfCourse()
        {
            return Course.GetCourseName() + ";" + Course.GetLenghtInWeeks() + ";" + Course.GetCompledtedLecturesCount() + ";" + Course.GetProgress() + ";" + Course.GetLastAccesed();
        }
    }
}
