﻿using Kreta.Shared.Enums;

namespace Kreta.Shared.Models
{
    public class Student : IDbEntity<Student>
    {
        public Student(string firstName, string lastName, DateTime birthsDay, bool isWooman,string placeOfBirth, int schoolYear, SchoolClassType schoolClass, string educationLevel)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthsDay;
            PlaceOfBirth = placeOfBirth;
            IsWoman = isWooman;
            SchoolYear = schoolYear;
            SchoolClass = schoolClass;
            EducationLevel = educationLevel;
        }

        public Student()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthDay = new DateTime();
            PlaceOfBirth = string.Empty;
            IsWoman = false;
            SchoolYear = 9;
            SchoolClass = SchoolClassType.ClassA;
            EducationLevel = string.Empty;
            PlaceOfBirth= string.Empty;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PlaceOfBirth { get; set; }
        public bool IsWoman { get; set; }
        public int SchoolYear { get; set; }
        public SchoolClassType SchoolClass { get; set; }
        public string EducationLevel { get; set; }
        public bool HasId => Id != Guid.Empty;
        public bool IsMan => !IsWoman;
        public string HungarianName => $"{LastName} {FirstName}";

        public override string ToString()
        {
            string woman = IsWoman ? "nő" : "férfi";
            return $"{HungarianName} {woman} ({SchoolYear}.{SchoolClass}) - ({String.Format("{0:yyyy.MM.dd.}", BirthDay)}) ({EducationLevel})";
        }
    }
}
