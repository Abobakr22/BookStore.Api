using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;

namespace BookStore.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            // we map the data of the book class to bookmodel 
            CreateMap<Book, BookModel>();

            // reverse
            //CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
