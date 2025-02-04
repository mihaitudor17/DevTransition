using NumberFromString;
using System.Configuration;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NumberFromString.Config;
using NumberFromString.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("./Config/appSettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<FileProcessingOptions>(
                    context.Configuration.GetSection("FileProcessing")
                );
                services.AddTransient<FileProcessor>();
            })
            .Build();
        
        using (var scope = host.Services.CreateScope())
        {
            var fileProcessor = scope.ServiceProvider.GetRequiredService<FileProcessor>();
            int result = fileProcessor.ProcessFile();
            Console.WriteLine(result);
        }
    }
}
