using AutoMapper;
using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Library.Core.Entities;
using System.Linq.Expressions;

namespace Library.Core.Services
{
    public class StudentService : BaseService<StudentDto, StudentSearchDto, StudentInsertDto, StudentUpdateDto, Student>, IStudentService
    {
        public StudentService(ILibraryDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override void AddFilter(StudentSearchDto search, ref IQueryable<Student> query)
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

        protected override Expression<Func<Student, object>> SortColumns(string sortBy)
        {
            return sortBy switch
            {
                nameof(Student.FirstName) => d => d.FirstName,
                nameof(Student.LastName) => d => d.LastName,
                _ => d => d.Id,
            };
        }
    }
}
