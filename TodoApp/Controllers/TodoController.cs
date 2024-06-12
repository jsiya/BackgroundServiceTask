using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.BackgroundServices;
using TodoApp.Contexts;
using TodoApp.Models.Entities.Concretes;
using TodoApp.Models.ViewModels;

namespace TodoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetAll")]
    public  IActionResult GetAll()
    {
        return Ok("Hershey okaydir");
    }

    [HttpPost("AddItem")]
    public IActionResult AddToDoItem([FromBody] ToDoItemVM toDoItemVm)
    {
        var newItem = new TodoItem()
        {
            Description = toDoItemVm.Description,
            ExpireDateTime = DateTime.Now.AddMinutes(10),
            Title = toDoItemVm.Title,
            UserId = toDoItemVm.UserId
        };

        _context.TodoItems.Add(newItem);
        _context.SaveChanges();
        return Ok();
    }
}
