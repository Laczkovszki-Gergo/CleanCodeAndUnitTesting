using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week06FinalAssessment.Source.Abstraction.Clients
{
    public interface IMessageClient
    {
        Task SendNotification(string notificationMessage);
    }
}
