using Microsoft.EntityFrameworkCore;
using StudentASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentASP
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }


    }
}
