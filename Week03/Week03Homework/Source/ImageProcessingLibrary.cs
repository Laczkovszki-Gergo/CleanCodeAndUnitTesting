using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week03Homework.Source.Exceptions;

namespace Week03Homework.Source
{
    public class ImageProcessingLibrary
    {
        readonly Logger Logger;

        public ImageProcessingLibrary(Logger logger)
        {
            Logger = logger;
        }
        public async Task<string> ProcessImage(string input, string output)
        {
            try
            {
                Logger.Log("Processing image...");
                IsJpgFile(input);
                await Task.Delay(250);
                Logger.Log("Image processed successfully");
                return "Image content";
            }
            catch (InvalidImageException error) when (error is InvalidImageException && error.Message == "Invalid image format")
            {
                Logger.LogError(error.Message, error);
                throw new InvalidImageException(error.Message);
            }
            catch (ProcessingErrorException error) when (error is InvalidImageException && error.Message == "Image processing failed")
            {
                Logger.LogError(error.Message, error);
                throw new ProcessingErrorException(error.Message, error);
            }
            catch(Exception error)
            {
                Logger.LogError("Unknown error occured during processing image.", error);
                throw new Exception(error.Message);
            }
        }

        public async virtual Task<string> VirtualProcessImage(string input, string output)
        {
            return await ProcessImage(input, output);
        }

        private void IsJpgFile(string filePath)
        {
            if (!filePath.EndsWith(".jpg"))
            {
                InvalidImageException exception = new InvalidImageException("Invalid image format");
                Logger.LogError(exception.Message, exception);
                throw exception;
            }
        }
    }
}
