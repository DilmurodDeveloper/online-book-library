using Microsoft.AspNetCore.Mvc;
using OnlineBookLibrary.Server.Dtos;
using OnlineBookLibrary.Server.Interfaces;
using OnlineBookLibrary.Shared.Response;

namespace OnlineBookLibrary.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<BookDto>>>> GetAll()
        {
            var result = await _service.GetAllBooksAsync();
            return Ok(new ApiResponse<List<BookDto>> { Success = true, Data = result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BookDto>>> Get(int id)
        {
            var result = await _service.GetBookByIdAsync(id);
            if (result == null) return NotFound(new ApiResponse<BookDto> { Success = false, Message = "Not Found" });

            return Ok(new ApiResponse<BookDto> { Success = true, Data = result });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<BookDto>>> Create(CreateBookDto dto)
        {
            var result = await _service.CreateBookAsync(dto);
            return Ok(new ApiResponse<BookDto> { Success = true, Data = result });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Update(int id, CreateBookDto dto)
        {
            var updated = await _service.UpdateBookAsync(id, dto);
            if (!updated) return NotFound(new ApiResponse<string> { Success = false, Message = "Not Found" });

            return Ok(new ApiResponse<string> { Success = true, Message = "Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Delete(int id)
        {
            var deleted = await _service.DeleteBookAsync(id);
            if (!deleted) return NotFound(new ApiResponse<string> { Success = false, Message = "Not Found" });

            return Ok(new ApiResponse<string> { Success = true, Message = "Deleted Successfully" });
        }
    }
}
