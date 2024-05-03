using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week03Homework.Source;
using Week03Homework.Source.Exceptions;

namespace Week03Homework.Test
{
    [TestFixture]
    public class ImageProcessorTest
    {
        ImageProcessor imageProcessor;
        Mock<ImageProcessor> mockedImageProcessor;
        Mock<ImageProcessingLibrary> mockedImageProcessingLibrary;
        Mock<FileStorageLibrary> mockedFileStorageLibrary;
        Mock<Logger> mockedLogger;
        Mock<IConsole> console;

        const string input = @"C:\Users\laczkovszki.gergo\Desktop\Cubix\ImagesBefureProcess\Image.jpg";
        const string output = @"C:\Users\laczkovszki.gergo\Desktop\Cubix\ImagesAfterProcess\ProcessedImage.jpg";

        [SetUp]
        public void SetUp()
        {
            console = new Mock<IConsole>();
            mockedLogger = new Mock<Logger>(console.Object);
            mockedImageProcessingLibrary = new Mock<ImageProcessingLibrary>(mockedLogger.Object);
            mockedFileStorageLibrary = new Mock<FileStorageLibrary>(mockedLogger.Object);
            imageProcessor = new ImageProcessor(mockedImageProcessingLibrary.Object, mockedFileStorageLibrary.Object);
            mockedImageProcessor = new Mock<ImageProcessor>(mockedImageProcessingLibrary.Object, mockedFileStorageLibrary.Object);
        }

        [Test]
        public async Task ProcessAndSaveImage_ShouldReturnASuccessfulMessage()
        {
            // Arrange

            // Act
            await imageProcessor.ProcessAndSaveImage(input, output);

            // Assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(4));
            mockedLogger.Verify(x => x.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never);
        }

        [Test]
        [TestCase("Image processing failed")]
        [TestCase("Image saving failed")]
        public async Task ProcessAndSaveImage_ShouldThrowProcessingErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new ProcessingErrorException(exceptedExceptionMessage, error);
            mockedImageProcessor.Setup(x => x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<ProcessingErrorException>(() => mockedImageProcessor.Object.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedImageProcessor.Verify(x=>x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        [TestCase("Invalid image format")]
        public async Task ProcessAndSaveImage_ShouldThrowInvalidImageErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new InvalidImageException(exceptedExceptionMessage);
            mockedImageProcessor.Setup(x => x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>())).Throws(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<InvalidImageException>(() => mockedImageProcessor.Object.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedImageProcessor.Verify(x => x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        [Test]
        public async Task ProcessAndSaveImage_ShouldThrowUnknownException()
        {
            // Arrange
            var expectedError = new Exception();
            mockedImageProcessor.Setup(x => x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>())).Throws(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => mockedImageProcessor.Object.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedImageProcessor.Verify(x => x.VirtualProcessAndSaveImage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
