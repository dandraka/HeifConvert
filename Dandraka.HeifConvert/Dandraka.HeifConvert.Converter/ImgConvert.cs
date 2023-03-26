using ImageMagick;
using System.IO;

namespace Dandraka.HeifConvert.Converter
{
    public enum ImageType
    {
        png,
        jpg,
        gif,
        tiff,
        bmp
    }
    public static class ImgConvert
    {
        public static void ConvertFile(string inputfilename, ImageType? convertType = ImageType.jpg, string? outputfilename = null)
        {
            if (string.IsNullOrEmpty(outputfilename))
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string dir = Path.GetDirectoryName(inputfilename);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                outputfilename = Path.Combine(dir, Path.ChangeExtension(inputfilename, convertType.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }
            using (var image = new MagickImage(inputfilename))
            {
                image.Write(outputfilename);
            }
        }

        public static void ConvertFiles(List<string> inputfilenameList)
        {
            foreach (string inputfilename in inputfilenameList)
            {
                ConvertFile(inputfilename);
            }
        }

        public static void ConvertDir(string inputDir, string filters = "*.heif;*.heic")
        {
            // support multiple filters eg. *.heif;*.heic
            var list = filters.Split(';')
                .SelectMany(d => Directory.GetFiles(inputDir, d))
                .ToList();
            foreach (string inputfilename in list)
            {
                ConvertFile(inputfilename);
            }
        }
    }
}