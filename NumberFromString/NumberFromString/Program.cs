using NumberFromString;
using System.Text.RegularExpressions;

public class Program
{
    private static void Main()
    {
        var lines = File.ReadLines(Constants.filePath);
        int number = 0;
        foreach(var line in lines)
        {
            var resultString = Regex.Matches(line, Constants.regexPattern);
            number += Int32.Parse($"{resultString.First()}{resultString.Last()}");
        }
        Console.WriteLine(number);
    }
}
