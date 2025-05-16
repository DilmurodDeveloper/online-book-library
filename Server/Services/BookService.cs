using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Server.Data;
using OnlineBookLibrary.Server.Dtos;
using OnlineBookLibrary.Server.Interfaces;
using OnlineBookLibrary.Server.Models;


namespace OnlineBookLibrary.Server.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BookService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _context.Books!.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> UpdateBookAsync(int id, CreateBookDto dto)
        {
            var book = await _context.Books!.FindAsync(id);
            if (book == null) return false;

            _mapper.Map(dto, book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
