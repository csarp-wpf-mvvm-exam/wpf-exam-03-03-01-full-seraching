using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class TeacherDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; } = DateTime.MinValue;
        public bool IsHeadTeacher { get; set; } = false;

    }
}
