using AutoMapper;
using Library.Common.Shared;
using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BorrowService : BaseService<BorrowDto, BorrowSearchDto, BorrowInsertDto, BorrowUpdateDto, Borrow>, IBorrowService
    {
        public BorrowService(ILibraryDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public override Task<PagedResult<BorrowDto>> SearchAsync(BorrowSearchDto search)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.BookName))
                {
                    search.Includes.Add("Book");
                }

                if (!string.IsNullOrEmpty(search.StudentName))
                {
                    search.Includes.Add("Student");
                }
            }
            else
            {
                search = new BorrowSearchDto();
            }

            return base.SearchAsync(search);
        }

        protected override void AddFilter(BorrowSearchDto search, ref IQueryable<Borrow> query)
        {
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.BookName))
                {
                    query = query.Where(x => x.Book != null && x.Book.Title.ToLower() == search.BookName.ToLower());
                }

                if (!string.IsNullOrEmpty(search.StudentName))
                {
                    query = query.Where(x => x.Student != null && x.Student.FirstName != null && x.Student.FirstName.ToLower() == search.StudentName.ToLower());
                }
            }
        }

        protected override Expression<Func<Borrow, object>> SortColumns(string sortBy)
        {
            return sortBy switch
            {
                nameof(Borrow.TakenDate) => d => d.TakenDate,
                nameof(Borrow.ReturnDate) => d => d.ReturnDate,
                _ => d => d.Id,
            };
        }
    }
}
