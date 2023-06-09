# HeifConvert

## Introduction

HeifConvert is a WIndows command line utility that converts HEIF/HEIC images to other formats such as Jpeg and Png. HEIF/HEIC images use the [High Efficiency Image File Format](https://www.iso.org/standard/66067.html) which is adopted by Apple and used by default in most iOS devices. The main use case for this utility is to convert photos taken from an iPhone or an iPad to Jpeg, so that they can be used in non-iOS applications such as websites, tools etc. 

My personal driver to write this utility is the family yearly calendar. See, every year I use an online service -there are many- where I can upload family pictures and get a calendar printed. I order multiple copies, for us, for our parents to see their grandchildren, for our siblings to see their nieces etc. But the constant problem is that these services only support Jpeg, Png and maybe Tiff image files.

## Installation

No installation is needed. Just download the zip and unzip it in a folder of your choice (e.g. C:\app\HeifConvert). You're ready to go.

## Usage

`HeifConvert.exe [-o output type] -p path`

- `-o` or `-outputtype` is optional. If omitted, Jpeg is used. Examples are -o jpeg, -o png, -o tiff.

- `-p` or `-path` is an absolute path to a file or directory. If the path is a single file, it is converted as specified by the `-o` parameter. If the path is a directory, all *.heic and *.heif files are converted. In both cases, the filename is kept the same except for the extension. **_Any prexisting files are overwritten_**.

## Examples

### Using Windows command line (cmd)

- `C:\app\HeifConvert\HeifConvert.exe -p C:\myphotos\weddingphoto.heic`
- `C:\app\HeifConvert\HeifConvert.exe -o png -p "C:\myphotos\Holidays in Rethymno photos"`

### Using Powershell

**TODO**

## Credits

This utility is basically a front end to the excellent [ImageMagick](https://imagemagick.org/) library, used via the [Magick.NET](https://www.nuget.org/packages/Magick.NET-Q16-AnyCPU) nuget package.