using AutoMapper;
using Library.Core.Common.Dtos;
using Library.Core.Entities;

namespace Library.Core.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookInsertDto, Book>();
            CreateMap<BookUpdateDto, Book>();
            CreateMap<Book, BookDto>()
                .ForMember(x => x.Authors, y => y.MapFrom(z => z.BookAuthors.Select(a => a.Author)));

            CreateMap<AuthorInsertDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorDto>();

            CreateMap<StudentInsertDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<BorrowInsertDto, Borrow>();
            CreateMap<BorrowUpdateDto, Borrow>();
            CreateMap<Borrow, BorrowDto>();
        }
    }
}