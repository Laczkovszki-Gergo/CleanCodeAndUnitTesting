using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Abstraction.Services
{
    public interface IPaymentService
    {
        Task<bool> GetIsOrderPayed(Student student,Course course);
    }
}
