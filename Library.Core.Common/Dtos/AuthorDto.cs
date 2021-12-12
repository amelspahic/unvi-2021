namespace Library.Core.Common.Dtos
{
    public class AuthorDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? BirthPlace { get; set; }
    }
}
