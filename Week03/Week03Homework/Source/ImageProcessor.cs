using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week03Homework.Source.Exceptions;

namespace Week03Homework.Source
{
    public class ImageProcessor
    {
        readonly ImageProcessingLibrary ImageProcessingLibrary;
        readonly FileStorageLibrary FileStorageLibrary;

        public ImageProcessor(ImageProcessingLibrary imageProcessingLibrary, FileStorageLibrary fileStorageLibrary)
        {
            ImageProcessingLibrary = imageProcessingLibrary;
            FileStorageLibrary = fileStorageLibrary;
        }

        //Azért kell, hogy tudjam tesztelni például, hogy történt-e logget hívás és egyebek, mert virtualként olyan, mintha nem is használná.
        //Tudom, hogy nem túl elegáns megoldás, egyelőre ez a workaround jutott eszembe.
        public async Task ProcessAndSaveImage(string input, string output)
        {
            var content = await ImageProcessingLibrary.ProcessImage(input, output);
            await FileStorageLibrary.SaveContentIntoFile(output,content);
        }

        //Mockolt objektumokat csak virtual-ként engedi tesztelni, utána olvastam a neten
        //https://stackoverflow.com/questions/11738102/how-to-mock-non-virtual-methods
        //https://www.reddit.com/r/csharp/comments/16jawub/how_do_i_mock_nonvirtual_methods_in_csharp/
        //Lehet más nugeteket kellene használnom..
        public virtual async Task VirtualProcessAndSaveImage(string input, string output)
        {
            await ProcessAndSaveImage(input, output);
        }
    }
}
