namespace Library.Core.Entities
{
    public class Borrow : BaseEntity
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateOnly TakenDate { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}