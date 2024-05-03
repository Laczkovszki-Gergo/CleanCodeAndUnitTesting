using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Abstraction.Clients
{
    public interface IFinancialApiClient
    {
        Task<bool> CheckPaymentStatus(Student student, Course course);
        Task<bool> PayForCourse(Student student, Course course);
    }
}
