using Library.Common.Shared;

namespace Library.Core.Common.Interfaces
{
    public interface IBaseService<T, TSearch, TInsert, TUpdate>
    {
        Task<T> GetByIdAsync(int id);

        Task<PagedResult<T>> SearchAsync(TSearch search);

        Task<T> InsertAsync(TInsert insert);

        Task<T> UpdateAsync(int id, TUpdate update);
    }
}
