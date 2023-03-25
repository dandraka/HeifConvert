using ImageMagick;

namespace Dandraka.HeifConvert.Converter
{
    public enum ImageType
    {
        Png,
        Jpg,
        Gif,
        Tiff,
        Bmp
    }
    public static class ImgConvert
    {
        public static void ConvertFile(string inputfilename, ImageType? convertType = ImageType.Jpg, string? outputfilename = null)
        {
            if (string.IsNullOrEmpty(outputfilename))
            {
                string dir = Path.GetDirectoryName(inputfilename);
                outputfilename = Path.Combine(dir, Path.ChangeExtension(inputfilename, convertType.ToString()));
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

        public static void ConvertDir(string inputDir, string filter)
        {
            var list = Directory.GetFiles(inputDir, filter);
            foreach (string inputfilename in list)
            {
                ConvertFile(inputfilename);
            }
        }
    }
}