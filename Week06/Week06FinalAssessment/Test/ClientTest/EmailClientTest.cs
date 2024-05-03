using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Exceptions;
using Week06FinalAssessment.Source.Models;

namespace Week06FinalAssessment.Test.ClientTest
{
    [TestFixture]
    public class EmailClientTest
    {
        string NotificationMessage = "Test notification message";
        EmailClient EmailClient;


        [SetUp]
        public void Setup()
        {
            EmailClient = new EmailClient();
        }
        [Test]
        public async Task SendNotification_ValidNotificationMessage_ConsoleOutputContainsMessage()
        {
            // Arrange
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            await EmailClient.SendNotification(NotificationMessage);

            // Assert
            var outputLines = consoleOutput.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            ClassicAssert.IsTrue(outputLines.Any(line => line.Contains($"Sending email notification: {NotificationMessage}")));
        }
        [Test]
        public void SendNotification_NullNotificationMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var emailClient = new EmailClient();

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => emailClient.SendNotification(null));
        }

        [Test]
        public void SendNotification_EmptyNotificationMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var notificationMessage = "";

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => EmailClient.SendNotification(notificationMessage));
        }
    }
}
