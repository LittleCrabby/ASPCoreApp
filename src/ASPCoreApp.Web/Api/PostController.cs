using System.Linq;
using ASPCoreApp.Core.Entities;
using ASPCoreApp.Core.Interfaces;
using ASPCoreApp.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreApp.Web.Api
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IRepository<Post> _postRepository;

        public PostsController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        
        [HttpGet]
        public IActionResult List()
        {
            var items = _postRepository.List()
                            .Select(item => PostDTO.FromPost(item));
            return Ok(items);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = PostDTO.FromPost(_postRepository.GetById(id));
            return Ok(item);
        }
    }
}
