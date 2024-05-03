using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Abstraction.Services;

namespace Week06FinalAssessment.Source.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<IMessageClient> messageClients;

        public NotificationService(IEnumerable<IMessageClient> messageClients)
        {
            this.messageClients = messageClients.ToList();
        }

        public async Task SendNotifications(string notificationMessage)
        {
            if (string.IsNullOrEmpty(notificationMessage))
                throw new ArgumentNullException(nameof(notificationMessage), "Notification message cannot be null or empty.");

            foreach (var client in messageClients)
            {
                await client.SendNotification(notificationMessage);
            }
        }
    }
}
