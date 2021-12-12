using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : BaseController<BorrowDto, BorrowSearchDto, BorrowInsertDto, BorrowUpdateDto>
    {
        public BorrowsController(IBorrowService service) : base(service)
        {
        }
    }
}
