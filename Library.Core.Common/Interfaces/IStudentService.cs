using Library.Core.Common.Dtos;

namespace Library.Core.Common.Interfaces
{
    public interface IStudentService : IBaseService<StudentDto, StudentSearchDto, StudentInsertDto, StudentUpdateDto>
    {
        //Task<StudentDto> GetById(int id);
        //Task<StudentDto> GetAll(StudentSearchDto search);
        //Task<StudentDto> Update(int id, StudentUpdateDto update);
        //Task<StudentDto> Insert(StudentInsertDto insert);
    }
}
