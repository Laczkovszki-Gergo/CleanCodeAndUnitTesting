using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Abstraction.Services;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Source.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IFinancialApiClient financialApiClient;

        public PaymentService(IFinancialApiClient financialApiClient)
        {
            this.financialApiClient = financialApiClient;
        }

        public async Task<bool> GetIsOrderPayed(Student student, Course course)
        {
            return await financialApiClient.CheckPaymentStatus(student, course);
        }

        public async Task<bool> PayForCourse(Student student, Course course)
        {
            return await financialApiClient.PayForCourse(student, course);
        }
    }
}
