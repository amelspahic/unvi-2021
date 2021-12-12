namespace Library.Core.Common.Dtos
{
    public class BookDto : BaseDto
    {
        public BookDto()
        {
            Authors = new();
        }

        public string? Title { get; set; }
        public int Published { get; set; }
        public int Stock { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
