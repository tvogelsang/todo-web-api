using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Attributes;
using TodoWebApi.Entity;
using TodoWebApi.Models;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<LoginController> _logger;

        public TodoController(ITodoService todoService, ILogger<LoginController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        public User CurrentUser
        {
            get
            {
                return HttpContext.Items["User"] as User;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            var todo = _todoService.Get(
                CurrentUser
            );

            var item = todo.Items
                .Where(i => i.Id == id)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            todo.Items.Remove(item);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            var todo = _todoService.Get(
                CurrentUser
            );

            return Ok(todo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post(TodoModel model)
        {
            var todo = _todoService.Get(
                CurrentUser
            );

            var item = new TodoItem
            {
                Title = model.Title
            };

            todo.Items.Insert(0, item);

            return Ok(item.Id);
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(Guid id, TodoModel model)
        {
            var todo = _todoService.Get(
                CurrentUser
            );

            var item = todo.Items
                .Where(i => i.Id == id)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            item.Completed = model.Completed;
            item.Title = model.Title;

            return Ok();
        }
    }
}