using Library.Core.Common.Dtos;

namespace Library.Core.Common.Interfaces
{
    public interface IAuthorService : IBaseService<AuthorDto, AuthorSearchDto, AuthorInsertDto, AuthorUpdateDto>
    {
        //Task<AuthorDto> GetById(int id);
        //Task<AuthorDto> GetAll(AuthorSearchDto search);
        //Task<AuthorDto> Update(int id, AuthorUpdateDto update);
        //Task<AuthorDto> Insert(AuthorInsertDto insert);
    }
}
