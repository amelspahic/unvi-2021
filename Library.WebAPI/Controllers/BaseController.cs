using Library.Core.Common.Dtos;
using Library.Core.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class BaseController<T, TSearch, TInsert, TUpdate> : ControllerBase
        where T : BaseDto, new()
    {
        private readonly IBaseService<T, TSearch, TInsert, TUpdate> _service;

        public BaseController(IBaseService<T, TSearch, TInsert, TUpdate> service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetPagedAsync([FromQuery] TSearch search)
        {
            var res = await _service.SearchAsync(search);
            return Ok(res);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _service.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(TInsert insert)
        {
            var res = await _service.InsertAsync(insert);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = res.Id }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TUpdate update)
        {
            var res = await _service.UpdateAsync(id, update);
            return Ok(res);
        }
    }
}
