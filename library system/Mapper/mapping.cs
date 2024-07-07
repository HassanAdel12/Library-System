using AutoMapper;
using library_system.Core.DTO;
using library_system.Core.Models;

namespace library_system.Mapper
{
    public class mapping : Profile
    {
        public mapping()
        {

            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

        }
    }
}
