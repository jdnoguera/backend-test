using Microsoft.AspNetCore.Mvc;

namespace backend_test.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private static List<Todo> todoList = new List<Todo>
    {
        new Todo
        {
            Id = 1,
            Description = "Prueba"
        }
    };
    
    [HttpGet]
    public async Task<ActionResult<List<Todo>>> Get()
    {
        return Ok(todoList);
    }

    [HttpPost]
    public async Task<ActionResult<List<Todo>>> AddTodo(Todo todo)
    {
        todoList.Add(todo);
        return Ok(todoList);
    }
    
 }