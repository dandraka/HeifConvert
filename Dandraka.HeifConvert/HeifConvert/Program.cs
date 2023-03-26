// See https://aka.ms/new-console-template for more information
using Dandraka.HeifConvert.Converter;

// convert heic/heif to jpg
string dir = args[0];
ImgConvert.ConvertDir(dir);