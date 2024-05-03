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
    public class PushNotificationClient : IMessageClient
    {
        public async Task SendNotification(string notificationMessage)
        {
            try
            {
                ClientValidator.ValidateNotificationMessage(notificationMessage);

                Console.WriteLine($"Sending push notification: {notificationMessage}");
                await Task.Delay(100);
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
    }
}
