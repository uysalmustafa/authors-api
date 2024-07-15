using AuthorsAPI.DTO;
using AuthorsAPI.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuthorsAPI.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
        }
    }

}
