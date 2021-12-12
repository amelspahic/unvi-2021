using Library.Core.Common.Dtos;

namespace Library.Core.Common.Interfaces
{
    public interface IBorrowService : IBaseService<BorrowDto, BorrowSearchDto, BorrowInsertDto, BorrowUpdateDto>
    {
        //Task<BorrowDto> GetById(int id);
        //Task<BorrowDto> GetAll(BorrowSearchDto search);
        //Task<BorrowDto> Update(int id, BorrowUpdateDto update);
        //Task<BorrowDto> Insert(BorrowInsertDto insert);
    }
}
