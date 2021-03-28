using GraphQL.Sample.Domain.Models;
using GraphQL.Sample.Infrastructure.Data.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace GraphQL.Sample.Infrastructure.Data.Ef
{
    public class SchoolDbContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolPeriod> SchoolPeriods { get; set; }
        public DbSet<SchoolPeriodCourse> SchoolPeriodCourses { get; set; }


        public SchoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Add queries to be log on the console
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseLoggerFactory(_loggerFactory);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseStudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseTeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolPeriodCourseConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
