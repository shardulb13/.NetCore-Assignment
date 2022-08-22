using Microsoft.EntityFrameworkCore;
using StudentCollegeRepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCollegeRepositoryPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StudentEntity> StudentTable { get; set; }
        public DbSet<CollegeEntity> CollegeTable { get; set; }
    }
}
