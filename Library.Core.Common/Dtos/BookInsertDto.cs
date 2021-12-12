namespace Library.Core.Common.Dtos
{
    public class BookInsertDto
    {
        public BookInsertDto()
        {
            AuthorIds = new();
        }
        public string? Title { get; set; }
        public int? Published { get; set; }
        public int? Stock { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
