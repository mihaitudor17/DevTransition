using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using NumberFromString.Config;

namespace NumberFromString.Services;

public class FileProcessor
{
    private readonly string filePath;

    public FileProcessor(IOptions<FileProcessingOptions> options)
    {
        filePath = options.Value.FilePath;
    }

    public int ProcessFile()
    {
        var lines = File.ReadLines(filePath);
        int number = 0;
        foreach(var line in lines)
        {
            var resultString = Regex.Matches(line, Constants.regexPattern);
            number += Int32.Parse($"{resultString.First()}{resultString.Last()}");
        }
        return number;
    }
}