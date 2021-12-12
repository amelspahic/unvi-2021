using AutoMapper;
using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Core.Services
{
    public class BookService : BaseService<BookDto, BookSearchDto, BookInsertDto, BookUpdateDto, Book>, IBookService
    {
        public BookService(ILibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async override Task<BookDto> InsertAsync(BookInsertDto request)
        {
            var entity = _mapper.Map<Book>(request);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(InsertAsync) ,"Podaci za unos knjige ne postoje");
            }

            _context.Add(entity);

            foreach (var item in request.AuthorIds)
            {
                _context.BookAuthor.Add(new BookAuthor
                {
                    Book = entity,
                    AuthorId = item
                });
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(entity);
        }

        protected override void AddFilter(BookSearchDto search, ref IQueryable<Book> query)
        {
            if (search != null)
            {
                if (search.Published.HasValue)
                {
                    query = query.Where(x => x.Published == search.Published.Value);
                }

                if (!string.IsNullOrEmpty(search.Title))
                {
                    query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
                }
            }
        }

        protected override Expression<Func<Book, object>> SortColumns(string sortBy)
        {
            return sortBy switch
            {
                nameof(Book.Title) => d => d.Title,
                nameof(Book.Stock) => d => d.Stock,
                _ => d => d.Id,
            };
        }
    }
}
