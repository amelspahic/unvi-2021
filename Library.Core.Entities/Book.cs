using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        [Required]
        public string Title { get; set; } = string.Empty;
        public int Published { get; set; }
        public int Stock { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}