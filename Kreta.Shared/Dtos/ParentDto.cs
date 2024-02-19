using Kreta.Shared.Enums;

namespace Kreta.Shared.Dtos
{
    public class ParentDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public bool IsWooman { get; set; }=false;
    }
}
