using System.ComponentModel.DataAnnotations;

namespace Library.Core.Common.Dtos
{
    public class BorrowInsertDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateOnly TakenDate { get; set; }
    }
}
