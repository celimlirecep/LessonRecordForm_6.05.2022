using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
    public class LessonRecordFormContext:DbContext
    {
        
        public LessonRecordFormContext(DbContextOptions<LessonRecordFormContext> options):base(options)
        {

        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Name=Connectionstrings:SqLiteConn");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentLesson>().HasKey(x => new { x.LessonId, x.StudentId });
        }



    }
}
