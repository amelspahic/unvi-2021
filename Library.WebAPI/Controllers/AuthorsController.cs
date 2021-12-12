using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController<AuthorDto, AuthorSearchDto, AuthorInsertDto, AuthorUpdateDto>
    {
        public AuthorsController(IAuthorService service) : base(service)
        {
        }
    }
}
