namespace Library.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? BirthPlace { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}