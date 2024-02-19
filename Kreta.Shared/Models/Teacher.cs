
namespace Kreta.Shared.Models
{
    public class Teacher : IDbEntity<Teacher>
    {
        public Teacher(Guid id, string firstName, string lastName, DateTime birthsDay,bool isHeadTeacher)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthsDay;
            IsHeadTeacher = isHeadTeacher;
        }

        public Teacher()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthDay = new DateTime();
            IsHeadTeacher = false;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsHeadTeacher { get;set; }
        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName} - ({String.Format("{0:yyyy.MM.dd.}", BirthDay)}))";
        }
    }
}
