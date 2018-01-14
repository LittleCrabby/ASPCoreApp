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
        private readonly IRepository<Post> _todoRepository;

        public PostsController(IRepository<Post> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult List()
        {
            var items = _todoRepository.List()
                            .Select(item => PostDTO.FromPost(item));
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = PostDTO.FromPost(_todoRepository.GetById(id));
            return Ok(item);
        }
    }
}
