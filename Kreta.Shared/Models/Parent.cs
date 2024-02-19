namespace Kreta.Shared.Models
{
    public class Parent : IDbEntity<Parent>
    {
        public Parent(Guid id, string firstName, string lastName, bool isWooman)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsWooman = isWooman;
        }

        public Parent()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            IsWooman = false;
        
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsWooman { get; set; }

        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
