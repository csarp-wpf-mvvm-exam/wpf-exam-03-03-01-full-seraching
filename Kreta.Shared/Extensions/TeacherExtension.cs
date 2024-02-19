using Kreta.Shared.Dtos;
using Kreta.Shared.Models;

namespace Kreta.Shared.Extensions
{
    public static class TeacherExtension
    {
        public static TeacherDto ToTeacherDto(this Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthDay = teacher.BirthDay,
                IsHeadTeacher = teacher.IsHeadTeacher,
            };
        }

        public static Teacher ToTeacher(this TeacherDto teacherdto)
        {
            return new Teacher
            {
                Id = teacherdto.Id,
                FirstName = teacherdto.FirstName,
                LastName = teacherdto.LastName,
                BirthDay = teacherdto.BirthDay,
                IsHeadTeacher = teacherdto.IsHeadTeacher
            };
        }
    }

}
