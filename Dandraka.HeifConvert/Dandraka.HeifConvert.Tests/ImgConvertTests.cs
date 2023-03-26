using Dandraka.HeifConvert.Converter;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Dandraka.HeifConvert.Tests
{
    public class ImgConvertTests: IDisposable
    {
        private string _testDir;

        private List<string> _testImages;

        private List<string> GetInputFiles()
        {
            return Directory.EnumerateFiles(_testDir)
                .Where(x => Regex.IsMatch(x.ToLowerInvariant(), "hei.$"))
                .ToList();
        }

        private List<string> GetOutputFiles()
        {
            return Directory.EnumerateFiles(_testDir)
                .Where(x => !Regex.IsMatch(x.ToLowerInvariant(), "hei.$"))
                .ToList();
        }

        public ImgConvertTests()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _testDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "images");
#pragma warning restore CS8604 // Possible null reference argument.
            _testImages = Directory.EnumerateFiles(_testDir).ToList();
        }

        public void Dispose()
        {
            this.GetOutputFiles().ForEach(x => File.Delete(x));
        }

        [Fact]
        public void T01_ConvertToJpeg()
        {
            ImgConvert.ConvertFiles(_testImages);
            var list = this.GetOutputFiles();
            Assert.Equal(this.GetInputFiles().Count, list.Count);
        }
    }
}