using AutoMapper;
using Blogging.DTO;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMockService _mockService;


        public BlogsController(IRepository repository, IMapper mapper, IMockService mockService)
        {
            _repository = repository;
            _mapper = mapper;
            _mockService = mockService;
        }

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var blogPosts = await _repository.GetAllAsync();
                return Ok(blogPosts);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving blog posts. {ex}");
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

        [HttpGet("GetExternal")]
        public async Task<IActionResult> GetExternal()
        {
            var external = await _mockService.GetExternalBlog();

            return Ok(external);
        }
    }
}
