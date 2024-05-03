using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week03Homework.Source.Exceptions;

namespace Week03Homework.Source
{
    public class FileStorageLibrary
    {
        readonly Logger Logger;

        public FileStorageLibrary(Logger logger)
        {
            Logger = logger;
        }
        public async Task SaveContentIntoFile(string FilePath, string content)
        {
            try
            {
                Logger.Log("Saving image file "+content+ "to " + FilePath);
                await Task.Delay(250);
                Logger.Log("Image saved successfully");
            }
            catch (ProcessingErrorException error) when (error is ProcessingErrorException)
            {
                Logger.LogError(error.Message, error);
                throw new ProcessingErrorException(error.Message, error);
            }
            catch (Exception error)
            {
                Logger.LogError("Unknown error occured during saving image: " + error.Message, error);
                throw new Exception("Unknown error occured during saving image: " +error.Message);
            }
        }
        public virtual async Task VirtualSaveContentIntoFile(string FilePath, string content)
        {
            await SaveContentIntoFile(FilePath, content);
        }
    }
}
