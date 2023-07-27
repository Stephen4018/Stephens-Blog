using AutoMapper;
using Blogging.DTO;
using Data.Models;

namespace Blogging.Mapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<CreateBlogDto, Blogs>();

        }
    }
}
