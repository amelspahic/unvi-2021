using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<StudentDto, StudentSearchDto, StudentInsertDto, StudentUpdateDto>
    {
        public StudentsController(IStudentService service) : base(service)
        {
        }
    }
}
