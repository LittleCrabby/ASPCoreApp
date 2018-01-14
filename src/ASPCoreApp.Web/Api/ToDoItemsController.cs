using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreApp.Core.Entities;
using ASPCoreApp.Core.Interfaces;
using ASPCoreApp.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreApp.Web.Api
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        private readonly IRepository<ToDoItem> _todoRepository;

        public ToDoItemsController(IRepository<ToDoItem> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public IActionResult List()
        {
            var items = _todoRepository.List()
                            .Select(item => ToDoItemDTO.FromToDoItem(item));
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = ToDoItemDTO.FromToDoItem(_todoRepository.GetById(id));
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public IActionResult Post([FromBody] ToDoItemDTO item)
        {
            var todoItem = new ToDoItem()
            {
                Title = item.Title,
                Description = item.Description
            };
            _todoRepository.Add(todoItem);
            return Ok(ToDoItemDTO.FromToDoItem(todoItem));
        }
    }
}
