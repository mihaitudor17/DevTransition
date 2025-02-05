using Microsoft.AspNetCore.Mvc;
using NumberFromFileAPI.Data;
using NumberFromFileAPI.Models;
using NumberFromFileAPI.Services;
using System.IO;
using System.Text;

namespace NumberFromFileAPI.Controllers
{
    public class NumberFromStringController : Controller
    {
        private readonly NumbersDbContext _context;

        public NumberFromStringController(NumbersDbContext context)
        {
            _context = context;
        }

        [HttpPost("ProcessFile")]
        public IActionResult ProcessFile([FromBody] FileData fileData)
        {
            string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            string filePath = Path.Combine(resourcesPath, fileData.FileName);
            System.IO.File.WriteAllText(filePath, fileData.Text);

            FileProcessor fileProcessor = new FileProcessor(filePath);
            var fileModel = new FileModel() { FileName = fileData.FileName, Result=fileProcessor.ProcessFile()};
            _context.FileModels.Add(fileModel);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("GetResult/{fileName}")]
        public IActionResult GetResult(string fileName)
        {
            var fileModel = _context.FileModels.FirstOrDefault(f => f.FileName == fileName);
            if (fileModel == null)
            {
                return NotFound();
            }
            return Ok(fileModel.Result);
        }
    }
}
