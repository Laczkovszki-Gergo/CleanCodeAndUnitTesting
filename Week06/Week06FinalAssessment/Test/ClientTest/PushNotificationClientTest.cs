using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week06FinalAssessment.Source.Clients;
using Week06FinalAssessment.Source.Exceptions;
using Moq;
using Week06FinalAssessment.Source.Abstraction.Clients;
using Week06FinalAssessment.Source.Models;
using Week06FinalAssessment.Source.Services;

namespace Week06FinalAssessment.Test.ClientTest
{
    [TestFixture]
    public class PushNotificationClientTest
    {
        PushNotificationClient PushNotificationClient;

        [SetUp]
        public void Setup()
        {
            PushNotificationClient = new PushNotificationClient();
        }

        [Test]
        public async Task SendNotification_SuccessfullySent_PushNotificationSent()
        {
            // Arrange
            string notificationMessage = "Test notification message";
            string expectedOutput = $"Sending push notification: {notificationMessage}";
            string actualOutput;

            // Set up console redirection
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                await PushNotificationClient.SendNotification(notificationMessage);
                sw.Flush();

                // Capture console output
                actualOutput = sw.ToString().Trim();
            }

            // Assert
            StringAssert.Contains(expectedOutput, actualOutput);
        }

        [Test]
        public void SendNotification_ExceptionThrown_PushNotificationSendingExceptionThrown()
        {
            // Arrange

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => PushNotificationClient.SendNotification(null));
        }

        [Test]
        public async Task SendNotification_ValidNotificationMessage_ConsoleOutputContainsMessage()
        {
            // Arrange
            var pushNotificationClient = new PushNotificationClient();
            var notificationMessage = "Test notification message";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            await pushNotificationClient.SendNotification(notificationMessage);

            // Assert
            var outputLines = consoleOutput.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            ClassicAssert.IsTrue(outputLines.Any(line => line.Contains($"Sending push notification: {notificationMessage}")));
        }

        [Test]
        public void SendNotification_NullNotificationMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var pushNotificationClient = new PushNotificationClient();
            string notificationMessage = null;

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => pushNotificationClient.SendNotification(notificationMessage));
        }

        [Test]
        public void SendNotification_EmptyNotificationMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var pushNotificationClient = new PushNotificationClient();
            var notificationMessage = "";

            // Act & Assert
            ClassicAssert.ThrowsAsync<ArgumentNullException>(() => pushNotificationClient.SendNotification(notificationMessage));
        }
    }
}
