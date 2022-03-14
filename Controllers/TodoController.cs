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
            Id = 0,
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

    [HttpDelete]
    public async Task<ActionResult<List<Todo>>> Delete()
    {
        todoList.Clear();
        return Ok(todoList);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Todo>>> DeleteById(int id)
    {
        var todoId = todoList.Find(t => t.Id == id);
        if (todoId == null)
        {
            return BadRequest("El id no existe");
        }
        todoList.Remove(todoId);
        return Ok(todoList);
    }
 }