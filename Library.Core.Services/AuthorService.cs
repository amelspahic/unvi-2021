using AutoMapper;
using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Library.Core.Entities;
using System.Linq.Expressions;

namespace Library.Core.Services
{
    public class AuthorService : BaseService<AuthorDto, AuthorSearchDto, AuthorInsertDto, AuthorUpdateDto, Author>, IAuthorService
    {
        public AuthorService(ILibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override void AddFilter(AuthorSearchDto search, ref IQueryable<Author> query)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.FirstName))
                {
                    query = query.Where(x => x.FirstName != null && x.FirstName.ToLower() == search.FirstName.ToLower());
                }

                if (!string.IsNullOrEmpty(search.LastName))
                {
                    query = query.Where(x => x.LastName != null && x.LastName.ToLower() == search.LastName.ToLower());
                }
            }
        }

        protected override Expression<Func<Author, object>> SortColumns(string sortBy)
        {
            return sortBy switch
            {
                nameof(Author.FirstName) => d => d.FirstName,
                nameof(Author.LastName) => d => d.LastName,
                _ => d => d.Id,
            };
        }
    }
}
