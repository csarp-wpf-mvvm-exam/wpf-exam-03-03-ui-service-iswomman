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
                    BirthsDay=new DateTime(2022,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2021,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Vas",
                    LastName="Alex",
                    BirthsDay=new DateTime(2022,7,7),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },                
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kis",
                    LastName="Márta",
                    BirthsDay=new DateTime(2019,9,9),
                    SchoolYear=12,
                    SchoolClass = SchoolClassType.ClassC,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szakos",
                    LastName="Szandra",
                    BirthsDay=new DateTime(2017,7,7),
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
                    BirthsDay=new DateTime(2000,10,10),                
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Mirjam",
                    LastName="Metek",
                    BirthsDay=new DateTime(2000,11,11),
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Feri",
                    LastName="Földrajz",
                    BirthsDay=new DateTime(2000,12,12),
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Éva",
                    LastName="Ének",
                    BirthsDay=new DateTime(2000,1,1),
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Adorján",
                    LastName="Angol",
                    BirthsDay=new DateTime(2000,3,3),
                }
            };
            List<Parent> parents = new List<Parent>
            {
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="László",
                    LastName="Nagy",
                    BirthsDay=new DateTime(2026,10,10),
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Petra",
                    LastName="Pénzes",
                    BirthsDay=new DateTime(2026,10,10),
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Ferenc",
                    LastName="Fukar",
                    BirthsDay=new DateTime(2026,10,10),
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Rozi",
                    LastName="Réti",
                    BirthsDay=new DateTime(2026,10,10),
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Hedvig",
                    LastName="Hosszú",
                    BirthsDay=new DateTime(2026,10,10),
                },
                new Parent
                {
                    Id=Guid.NewGuid(),
                    FirstName="Milán",
                    LastName="Magas",
                    BirthsDay=new DateTime(2026,10,10),
                }
            };


            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Parent>().HasData(parents);
        }
    }
}
