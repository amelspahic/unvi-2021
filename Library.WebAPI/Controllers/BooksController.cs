using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController<BookDto, BookSearchDto, BookInsertDto, BookUpdateDto>
    {
        public BooksController(IBookService service) : base(service)
        {
        }
    }
}
