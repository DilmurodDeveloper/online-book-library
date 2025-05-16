using OnlineBookLibrary.Server.Dtos;

namespace OnlineBookLibrary.Server.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto bookDto);
        Task<bool> UpdateBookAsync(int id, CreateBookDto bookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
