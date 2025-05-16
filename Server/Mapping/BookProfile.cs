using AutoMapper;
using OnlineBookLibrary.Server.Dtos;
using OnlineBookLibrary.Server.Models;

namespace OnlineBookLibrary.Server.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<CreateBookDto, Book>().ReverseMap();

            CreateMap<Book, BookDto>().ForMember(
                dest => dest.CategoryName, 
                opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateBookDto, Book>();
        }
    }
}
