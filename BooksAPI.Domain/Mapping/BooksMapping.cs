using AutoMapper;
using BooksAPI.Domain.Dto;

namespace BooksAPI.Domain.Mapping
{
    public class BooksMapping : Profile
    {
        public BooksMapping()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookSummaryDto>().ReverseMap();

            CreateMap<LibraryItem, LibraryItemDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserSummaryDto>().ReverseMap();
        }
    }
}
