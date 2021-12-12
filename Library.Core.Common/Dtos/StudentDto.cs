using Library.Common.Shared;

namespace Library.Core.Common.Dtos
{
    public class StudentDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
