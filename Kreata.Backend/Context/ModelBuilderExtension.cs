using Kreta.Shared.Enums;
using Kreta.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    BirthDay=new DateTime(2022,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthDay=new DateTime(2021,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Vas",
                    LastName="Alex",
                    BirthDay=new DateTime(2022,7,7),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },                
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kis",
                    LastName="Márta",
                    BirthDay=new DateTime(2019,9,9),
                    SchoolYear=12,
                    SchoolClass = SchoolClassType.ClassC,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szakos",
                    LastName="Szandra",
                    BirthDay=new DateTime(2017,7,7),
                    SchoolYear=13,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="szakképzés"
                }
            };
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Martin",
                    LastName="Magyar",
                    BirthDay=new DateTime(2000,10,10),                
                    IsHeadTeacher=false,
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Mirjam",
                    LastName="Metek",
                    BirthDay=new DateTime(2000,11,11),
                    IsHeadTeacher=true,
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Feri",
                    LastName="Földrajz",
                    BirthDay=new DateTime(2000,12,12),
                    IsHeadTeacher=true,
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Éva",
                    LastName="Ének",
                    BirthDay=new DateTime(2000,1,1),
                    IsHeadTeacher=false,
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Adorján",
                    LastName="Angol",
                    BirthDay=new DateTime(2000,3,3),
                    IsHeadTeacher=false,
                }
            };
            List<Parent> parents = new List<Parent>
            {
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="László",
                    LastName="Nagy",
                    IsWooman=false,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Petra",
                    LastName="Pénzes",
                    IsWooman=true,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Ferenc",
                    LastName="Fukar",
                    IsWooman=false,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Fruzsi",
                    LastName="Fukar",
                    IsWooman=true,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Hedvig",
                    LastName="Hosszú",
                    IsWooman=true,
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Milán",
                    LastName="Magas",
                    IsWooman=false,
                }
            };


            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Parent>().HasData(parents);
        }
    }
}
