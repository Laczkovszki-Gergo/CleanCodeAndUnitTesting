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
    internal class FileStorageLibraryTest
    {
        FileStorageLibrary fileStorageLibrary;
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
            fileStorageLibrary = new FileStorageLibrary(mockedLogger.Object);
            mockedFileStorageLibrary = new Mock<FileStorageLibrary>(mockedLogger.Object);
        }

        [Test]
        public async Task SaveContentIntoFile_RunSuccessfully()
        {
            // Act
            await fileStorageLibrary.SaveContentIntoFile(input, output);

            // Assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        [TestCase("Image processing failed")]
        [TestCase("Image saving failed")]
        public async Task ProcessAndSaveImage_ShouldThrowProcessingErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new ProcessingErrorException(exceptedExceptionMessage, error);
            mockedFileStorageLibrary.Setup(x => x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>())).ThrowsAsync(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<ProcessingErrorException>(() => mockedFileStorageLibrary.Object.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedFileStorageLibrary.Verify(x => x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        [TestCase("Invalid image format")]
        public async Task ProcessAndSaveImage_ShouldThrowInvalidImageErrorException(string exceptedExceptionMessage)
        {
            // Arrange
            var error = new Exception(exceptedExceptionMessage);
            var expectedError = new InvalidImageException(exceptedExceptionMessage);
            mockedFileStorageLibrary.Setup(x => x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>())).Throws(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<InvalidImageException>(() => mockedFileStorageLibrary.Object.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedFileStorageLibrary.Verify(x => x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task SaveContentIntoFile_ShouldThrowUnkownError()
        {
            //Arrange
            var expectedError = new Exception();
            mockedFileStorageLibrary.Setup(x=>x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>())).Throws(expectedError);

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => mockedFileStorageLibrary.Object.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()));

            //Assert
            ClassicAssert.AreEqual(expectedError.Message, exception.Message);
            mockedFileStorageLibrary.Verify(x => x.VirtualSaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
