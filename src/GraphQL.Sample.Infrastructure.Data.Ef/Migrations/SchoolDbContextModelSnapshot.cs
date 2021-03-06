// <auto-generated />
using GraphQL.Sample.Infrastructure.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQL.Sample.Infrastructure.Data.Ef.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            Name = "Economic 1"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            Name = "Economic 2"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentId = 1,
                            Name = "Economic 3"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentId = 1,
                            Name = "Economic 4"
                        },
                        new
                        {
                            Id = 5,
                            DepartmentId = 2,
                            Name = "Gramar 1"
                        },
                        new
                        {
                            Id = 6,
                            DepartmentId = 2,
                            Name = "Oral expression1"
                        },
                        new
                        {
                            Id = 7,
                            DepartmentId = 2,
                            Name = "Reading 1"
                        },
                        new
                        {
                            Id = 8,
                            DepartmentId = 2,
                            Name = "Reading 2"
                        },
                        new
                        {
                            Id = 9,
                            DepartmentId = 3,
                            Name = "National History 1"
                        },
                        new
                        {
                            Id = 10,
                            DepartmentId = 3,
                            Name = "National history 2"
                        },
                        new
                        {
                            Id = 11,
                            DepartmentId = 3,
                            Name = "Greek Mythology History 1"
                        },
                        new
                        {
                            Id = 12,
                            DepartmentId = 3,
                            Name = "Nordic Mythology History 2"
                        },
                        new
                        {
                            Id = 13,
                            DepartmentId = 4,
                            Name = "Computer Programming 1"
                        },
                        new
                        {
                            Id = 14,
                            DepartmentId = 4,
                            Name = "Databases 1"
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.CourseStudent", b =>
                {
                    b.Property<int>("SchoolPeriodCourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SchoolPeriodCourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            SchoolPeriodCourseId = 1,
                            StudentId = 3
                        },
                        new
                        {
                            SchoolPeriodCourseId = 1,
                            StudentId = 4
                        },
                        new
                        {
                            SchoolPeriodCourseId = 1,
                            StudentId = 5
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            StudentId = 6
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            StudentId = 7
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            StudentId = 5
                        },
                        new
                        {
                            SchoolPeriodCourseId = 3,
                            StudentId = 6
                        },
                        new
                        {
                            SchoolPeriodCourseId = 3,
                            StudentId = 5
                        },
                        new
                        {
                            SchoolPeriodCourseId = 4,
                            StudentId = 4
                        },
                        new
                        {
                            SchoolPeriodCourseId = 7,
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.CourseTeacher", b =>
                {
                    b.Property<int>("SchoolPeriodCourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("SchoolPeriodCourseId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeachers");

                    b.HasData(
                        new
                        {
                            SchoolPeriodCourseId = 1,
                            TeacherId = 8
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            TeacherId = 9
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            TeacherId = 10
                        },
                        new
                        {
                            SchoolPeriodCourseId = 3,
                            TeacherId = 10
                        },
                        new
                        {
                            SchoolPeriodCourseId = 7,
                            TeacherId = 8
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            AdministratorId = 1,
                            Name = "Economics",
                            SchoolId = 1
                        },
                        new
                        {
                            DepartmentId = 2,
                            AdministratorId = 2,
                            Name = "English",
                            SchoolId = 1
                        },
                        new
                        {
                            DepartmentId = 3,
                            AdministratorId = 2,
                            Name = "History",
                            SchoolId = 1
                        },
                        new
                        {
                            DepartmentId = 4,
                            AdministratorId = 1,
                            Name = "Engineering",
                            SchoolId = 1
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Email = "Kim.Abercrombie@email.com",
                            Lastname = "Abercrombie",
                            Name = "Kim",
                            PersonType = 0
                        },
                        new
                        {
                            PersonId = 2,
                            Email = "Gytis.Barzdukas@email.com",
                            Lastname = "Barzdukas",
                            Name = "Gytis",
                            PersonType = 0
                        },
                        new
                        {
                            PersonId = 3,
                            Email = "Peggy.Justice@email.com",
                            Lastname = "Justice",
                            Name = "Peggy",
                            PersonType = 2
                        },
                        new
                        {
                            PersonId = 4,
                            Email = "Fadi.Fakhouri@email.com",
                            Lastname = "Fakhouri",
                            Name = "Fadi",
                            PersonType = 2
                        },
                        new
                        {
                            PersonId = 5,
                            Email = "Roger.Harui@email.com",
                            Lastname = "Harui",
                            Name = "Roger",
                            PersonType = 2
                        },
                        new
                        {
                            PersonId = 6,
                            Email = "Yan.Li@email.com",
                            Lastname = "Li",
                            Name = "Yan",
                            PersonType = 2
                        },
                        new
                        {
                            PersonId = 7,
                            Email = "Laura.Norman@email.com",
                            Lastname = "Norman",
                            Name = "Laura",
                            PersonType = 2
                        },
                        new
                        {
                            PersonId = 8,
                            Email = "Nino.Olivotto@email.com",
                            Lastname = "Olivotto",
                            Name = "Nino",
                            PersonType = 1
                        },
                        new
                        {
                            PersonId = 9,
                            Email = "Daniel.Tang@email.com",
                            Lastname = "Tang",
                            Name = "Daniel",
                            PersonType = 1
                        },
                        new
                        {
                            PersonId = 10,
                            Email = "Alonso.Meredith@email.com",
                            Lastname = "Meredith",
                            Name = "Alonso",
                            PersonType = 1
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "-",
                            CountryCode = "US",
                            Name = "School 1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "-",
                            CountryCode = "DE",
                            Name = "Schule 2"
                        },
                        new
                        {
                            Id = 3,
                            Address = "-",
                            CountryCode = "PE",
                            Name = "Escuela 1"
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriod", b =>
                {
                    b.Property<int>("SchoolPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("SchoolPeriodId");

                    b.HasIndex("SchoolId");

                    b.ToTable("SchoolPeriods");

                    b.HasData(
                        new
                        {
                            SchoolPeriodId = 1,
                            Period = "2020",
                            SchoolId = 1
                        },
                        new
                        {
                            SchoolPeriodId = 2,
                            Period = "2021",
                            SchoolId = 1
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriodCourse", b =>
                {
                    b.Property<int>("SchoolPeriodCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("SchoolPeriodId")
                        .HasColumnType("int");

                    b.HasKey("SchoolPeriodCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SchoolPeriodId");

                    b.ToTable("SchoolPeriodCourses");

                    b.HasData(
                        new
                        {
                            SchoolPeriodCourseId = 1,
                            CourseId = 1,
                            Credits = 3,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 2,
                            CourseId = 2,
                            Credits = 4,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 3,
                            CourseId = 3,
                            Credits = 4,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 4,
                            CourseId = 4,
                            Credits = 5,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 5,
                            CourseId = 5,
                            Credits = 5,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 6,
                            CourseId = 6,
                            Credits = 3,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 7,
                            CourseId = 7,
                            Credits = 3,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 8,
                            CourseId = 8,
                            Credits = 3,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 9,
                            CourseId = 9,
                            Credits = 4,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 10,
                            CourseId = 10,
                            Credits = 4,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 11,
                            CourseId = 11,
                            Credits = 4,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 12,
                            CourseId = 12,
                            Credits = 5,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 13,
                            CourseId = 13,
                            Credits = 5,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 14,
                            CourseId = 14,
                            Credits = 5,
                            SchoolPeriodId = 2
                        },
                        new
                        {
                            SchoolPeriodCourseId = 15,
                            CourseId = 1,
                            Credits = 5,
                            SchoolPeriodId = 1
                        });
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Course", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.CourseStudent", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.SchoolPeriodCourse", "SchoolPeriodCourse")
                        .WithMany("CourseStudents")
                        .HasForeignKey("SchoolPeriodCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQL.Sample.Domain.Models.Person", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolPeriodCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.CourseTeacher", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.SchoolPeriodCourse", "SchoolPeriodCourse")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("SchoolPeriodCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQL.Sample.Domain.Models.Person", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolPeriodCourse");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Department", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.Person", "Administrator")
                        .WithMany("Departments")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GraphQL.Sample.Domain.Models.School", "School")
                        .WithMany("Departments")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("School");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriod", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.School", "School")
                        .WithMany("SchoolPeriods")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriodCourse", b =>
                {
                    b.HasOne("GraphQL.Sample.Domain.Models.Course", "Course")
                        .WithMany("SchoolPeriodCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraphQL.Sample.Domain.Models.SchoolPeriod", "SchoolPeriod")
                        .WithMany("SchoolPeriodCourses")
                        .HasForeignKey("SchoolPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("SchoolPeriod");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Course", b =>
                {
                    b.Navigation("SchoolPeriodCourses");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.Person", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("CourseTeachers");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.School", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("SchoolPeriods");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriod", b =>
                {
                    b.Navigation("SchoolPeriodCourses");
                });

            modelBuilder.Entity("GraphQL.Sample.Domain.Models.SchoolPeriodCourse", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("CourseTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
