using Library.Core.Common.Dtos;

namespace Library.Core.Common.Interfaces
{
    public interface IBookService : IBaseService<BookDto, BookSearchDto, BookInsertDto, BookUpdateDto>
    {
        //Task<BookDto> GetById(int id);
        //Task<BookDto> GetAll(BookSearchDto search);
        //Task<BookDto> Update(int id, BookUpdateDto update);
        //Task<BookDto> Insert(BookInsertDto insert);
    }
}
