using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Abstraction.Services
{
    public interface INotificationService
    {
        Task SendNotifications(string notificationMessage);
    }
}
