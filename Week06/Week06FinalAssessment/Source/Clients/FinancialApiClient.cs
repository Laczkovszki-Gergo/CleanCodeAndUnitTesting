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
    public class FinancialApiClient : IFinancialApiClient
    {
        public async Task<bool> CheckPaymentStatus(Student student, Course course)
        {
            try
            {
                ClientValidator.ValidateFinancialApiArguments(student, course, "Error occurred while processing payment");
                return await Task.FromResult(true);
            }
            catch (ArgumentNullException ex) when (ex is ArgumentNullException)
            {
                throw new ArgumentNullException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown error occurred while checking payment status: " + ex.Message, ex);
            }
        }

        public async Task<bool> PayForCourse(Student student, Course course)
        {
            try
            {
                ClientValidator.ValidateFinancialApiArguments(student, course, "Error occurred while processing payment");
                return await Task.FromResult(true);
            }
            catch (ArgumentNullException ex) when (ex is ArgumentNullException)
            {
                throw new ArgumentNullException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown error occurred while processing payment: " + ex.Message, ex);
            }
        }

    }
}
