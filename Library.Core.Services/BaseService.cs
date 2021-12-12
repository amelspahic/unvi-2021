using AutoMapper;
using Library.Common.Shared;
using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Core.Services
{
    public abstract class BaseService<TDto, TSearch, TInsert, TUpdate, TEntity> : IBaseService<TDto, TSearch, TInsert, TUpdate>
        where TEntity : BaseEntity, new()
        where TSearch : BaseSearch, new()
    {
        protected ILibraryDbContext _context;
        protected IMapper _mapper;

        public BaseService(ILibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async virtual Task<PagedResult<TDto>> SearchAsync(TSearch search)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            PagedResult<TDto> result = new();

            AddIncludes(search.Includes, ref query);
            AddFilter(search, ref query);
            AddOrder(search, ref query);
            AddPaging(search, ref query);

            if (search.IncludeCount.GetValueOrDefault(false))
            {
                result.Count = await CountAsync(query);
            }

            var queryResult = await query.ToListAsync();
            result.Data = _mapper.Map<List<TDto>>(queryResult);
            return result;
        }

        public async virtual Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async virtual Task<TDto> InsertAsync(TInsert request)
        {
            var entity = _mapper.Map<TEntity>(request);
            _context.Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async virtual Task<TDto> UpdateAsync(int id, TUpdate request)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        #region Protected virtual
        protected virtual int DefaultPageSize { get; set; } = 10;
        protected virtual void AddPaging(TSearch search, ref IQueryable<TEntity> query)
        {
            if (!search.RetrieveAll.GetValueOrDefault(false))
            {
                query = query.Skip(search.Page.GetValueOrDefault(0)
                    * search.PageSize.GetValueOrDefault(DefaultPageSize))
                    .Take(search.PageSize.GetValueOrDefault(DefaultPageSize));
            }
        }

        protected virtual void AddIncludes(List<string> includes, ref IQueryable<TEntity> query)
        {
            foreach (var item in includes.Where(x => !string.IsNullOrEmpty(x)))
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
        }

        protected virtual async Task<long> CountAsync(IQueryable<TEntity> query)
        {
            return await query.LongCountAsync();
        }

        protected virtual void AddOrder(TSearch search, ref IQueryable<TEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(search.SortBy))
            {
                query = search.SortOrder == SortOrder.DESCENDING ? query.OrderByDescending(SortColumns(search.SortBy)) : query.OrderBy(SortColumns(search.SortBy));
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }
        }
        #endregion

        #region Abstract
        protected abstract void AddFilter(TSearch search, ref IQueryable<TEntity> query);
        protected abstract Expression<Func<TEntity, object>> SortColumns(string sortBy);
        #endregion
    }
}