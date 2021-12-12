using System.ComponentModel.DataAnnotations;

namespace Library.Core.Common.Dtos
{
    public class AuthorInsertDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? BirthPlace { get; set; }
    }
}
