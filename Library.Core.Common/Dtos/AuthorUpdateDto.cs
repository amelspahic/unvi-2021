namespace Library.Core.Common.Dtos
{
    public class AuthorUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? BirthPlace { get; set; }
    }
}
