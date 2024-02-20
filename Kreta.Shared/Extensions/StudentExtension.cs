using Kreta.Shared.Dtos;
using Kreta.Shared.Models;

namespace Kreta.Shared.Extensions
{
    public static class StudentExtension
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDay = student.BirthDay,
                EducationLevel = student.EducationLevel,
                SchoolYear = student.SchoolYear,
                SchoolClass = student.SchoolClass,
            };
        }

        public static Student ToStudent(this StudentDto studentdto)
        {
            return new Student
            {
                Id = studentdto.Id,
                FirstName = studentdto.FirstName,
                LastName = studentdto.LastName,
                BirthDay = studentdto.BirthDay,
                EducationLevel = studentdto.EducationLevel,
                SchoolClass = studentdto.SchoolClass,  
                SchoolYear = studentdto.SchoolYear,
            };
        }
    }

}
