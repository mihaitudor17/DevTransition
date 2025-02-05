using Microsoft.Extensions.Options;
using NumberFromFileAPI.Config;
using NumberFromFileAPI.Utils;
using System.Text.RegularExpressions;

namespace NumberFromFileAPI.Services
{
    public class FileProcessor
    {
        private string _filePath;

        public FileProcessor(string filePath)
        {
            _filePath = filePath;
        }

        public int ProcessFile()
        {
            var lines = File.ReadLines(_filePath);
            int number = 0;
            foreach (var line in lines)
            {
                var resultString = Regex.Matches(line, Constants.regexPattern);
                number += Int32.Parse($"{resultString.First()}{resultString.Last()}");
            }
            return number;
        }
    }
}
