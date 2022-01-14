﻿using StudentASP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentASP.DataAccess.MSSQL.Entities;

namespace StudentASP.DataAccess.MSSQL
{
    public class DiaryAppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DiaryAppDbContext(DbContextOptions<DiaryAppDbContext> options) 
            : base(options)
        {
            
        }
    }
}