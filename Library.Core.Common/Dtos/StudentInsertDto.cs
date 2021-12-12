using Library.Common.Shared;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Common.Dtos
{
    public class StudentInsertDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
