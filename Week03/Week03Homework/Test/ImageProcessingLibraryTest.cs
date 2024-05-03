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
    public class ImageProcessingLibraryTest
    {
        ImageProcessingLibrary imageProcessingLibrary;
        Mock<ImageProcessingLibrary> mockedImageProcessingLibrary;

        Mock<Logger> mockedLogger;
        Mock<IConsole> console;

        const string input = @"C:\Users\laczkovszki.gergo\Desktop\Cubix\ImagesBefureProcess\Image.jpg";
        const string output = @"C:\Users\laczkovszki.gergo\Desktop\Cubix\ImagesAfterProcess\ProcessedImage.jpg";
        [SetUp]
        public void SetUp()
        {
            console = new Mock<IConsole>();
            mockedLogger = new Mock<Logger>(console.Object);
            imageProcessingLibrary = new ImageProcessingLibrary(mockedLogger.Object);
            mockedImageProcessingLibrary = new Mock<ImageProcessingLibrary>(mockedLogger.Object);
        }

        [Test]
        public async Task ProcessImage_ShouldReturnWithContert()
        {
            // Arrange
            string expectedValue = "Image content";

            // Act
            var result = await imageProcessingLibrary.ProcessImage(input, output);

            // Assert
            ClassicAssert.AreEqual(expectedValue, result);
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
            mockedLogger.Verify(x => x.LogError(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never);
        }

        [Test]
        [TestCase("Image processing failed")]
        [TestCase("Image saving failed")]
        public async Task ProcessImage_ShouldThrowProcessingErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new ProcessingErrorException(exceptedExceptionMessage, error);
            mockedImageProcessingLibrary.Setup(x => x.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<ProcessingErrorException>(() => mockedImageProcessingLibrary.Object.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedImageProcessingLibrary.Verify(x => x.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        [TestCase("Invalid image format")]
        public async Task ProcessAndSaveImage_ShouldThrowInvalidImageErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new InvalidImageException(exceptedExceptionMessage);
            mockedImageProcessingLibrary.Setup(x => x.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>())).Throws(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<InvalidImageException>(() => mockedImageProcessingLibrary.Object.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedImageProcessingLibrary.Verify(x => x.VirtualProcessImage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
