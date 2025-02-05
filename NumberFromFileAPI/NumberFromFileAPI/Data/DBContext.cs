using Microsoft.EntityFrameworkCore;
using NumberFromFileAPI.Models;
using System.Collections.Generic;

namespace NumberFromFileAPI.Data
{
    public class NumbersDbContext : DbContext
    {
        public NumbersDbContext(DbContextOptions<NumbersDbContext> options)
            : base(options)
        { }

        public DbSet<FileModel> FileModels { get; set; }
    }
}
