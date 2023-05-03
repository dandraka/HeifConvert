// See https://aka.ms/new-console-template for more information
using Dandraka.HeifConvert.Converter;
using Fclp;

string path = "";
ImageType imgType = ImageType.jpg;
getCommandlineArgs(args);

void getCommandlineArgs(string[] a)
{
    var p = new FluentCommandLineParser();
    p.Setup<string>('p', "Path")
        .WithDescription("Path to a HEIF/HEIC file or directory containing HEIF/HEIC files.")
        .Callback(x => path = x)
        .Required();
    p.Setup<ImageType>('o', "OutputType")
        .WithDescription("Supported output types: " + string.Join(',', Enum.GetNames(typeof(ImageType))))
        .Callback(x => imgType = x)
        .SetDefault(ImageType.jpg);
    //p.SetupHelp()

    p.Parse(a);
}

//sanity checks
if (string.IsNullOrWhiteSpace(path))
{
    throw new ArgumentException("Path (-p or -Path) must be specified.");
}
if (!File.Exists(path) && !Directory.Exists(path))
{
    throw new DirectoryNotFoundException(path);
}    

// convert heic/heif to jpg
if (Directory.Exists(path)) 
{
    ImgConvert.ConvertDir(path);
}
else
{
    ImgConvert.ConvertFile(path);
}