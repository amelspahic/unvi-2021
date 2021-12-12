namespace Library.Core.Common.Dtos
{
    public class BorrowDto : BaseDto
    {
        public StudentDto? Student { get; set; }
        public BookDto? Book { get; set; }
        public DateOnly TakenDate { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}
