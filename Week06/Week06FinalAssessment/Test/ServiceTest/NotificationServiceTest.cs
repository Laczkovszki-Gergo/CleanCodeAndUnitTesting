using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Test.NotificationServiceTests
{
    [TestFixture]
    public class NotificationServiceTest
    {
        private NotificationService NotificationService;
        private Mock<IMessageClient> MockEmailClient;
        private Mock<IMessageClient> MockPushNotificationClient;

        [SetUp]
        public void Setup()
        {
            MockEmailClient = new Mock<IMessageClient>();
            MockPushNotificationClient = new Mock<IMessageClient>();
            var messageClients = new List<IMessageClient> { MockEmailClient.Object, MockPushNotificationClient.Object };
            NotificationService = new NotificationService(messageClients);
        }

        [Test]
        public async Task SendNotifications_ValidNotificationMessage_AllClientsReceiveNotification()
        {
            // Arrange
            var notificationMessage = "Test notification message";

            // Act
            await NotificationService.SendNotifications(notificationMessage);

            // Assert
            MockEmailClient.Verify(client => client.SendNotification(notificationMessage), Times.Once);
            MockPushNotificationClient.Verify(client => client.SendNotification(notificationMessage), Times.Once);
        }

        [Test]
        public async Task SendNotifications_NullNotificationMessage_NoNotificationSent()
        {
            // Arrange

            // Act
            ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await NotificationService.SendNotifications(null));

            // Assert
            MockEmailClient.Verify(client => client.SendNotification(It.IsAny<string>()), Times.Never);
            MockPushNotificationClient.Verify(client => client.SendNotification(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task SendNotifications_EmptyNotificationMessage_NoNotificationSent()
        {
            // Arrange

            // Act
            ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await NotificationService.SendNotifications(""));

            // Assert
            MockEmailClient.Verify(client => client.SendNotification(It.IsAny<string>()), Times.Never);
            MockPushNotificationClient.Verify(client => client.SendNotification(It.IsAny<string>()), Times.Never);
        }
    }
}
