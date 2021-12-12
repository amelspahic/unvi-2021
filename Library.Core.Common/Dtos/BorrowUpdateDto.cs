namespace Library.Core.Common.Dtos
{
    public class BorrowUpdateDto
    {
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
        public DateOnly? TakenDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}
