using AutoMapper;
using Blogging.DTO;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{

    [Route("api/[controller]")]

    public class BlogsController : ControllerBase
    {
        public readonly IRepository _repository;
        private readonly IMapper _mapper;

        public BlogsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var blogPosts = await _repository.GetAllAsync();
                return Ok(blogPosts);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving blog posts.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto blog, string userID)
        {
            try
            {
                if (blog == null) throw new ArgumentNullException(nameof(blog));

                var Newblog = _mapper.Map<Blogs>(blog);
               var add = await _repository.AddAsync(Newblog, userID);
                
                    return Ok(add);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
