using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; } = DateTime.MinValue;
        public int SchoolYear { get; set; }
        public SchoolClassType SchoolClass { get; set; }
        public string EducationLevel { get; set; } = string.Empty;

    }
}
