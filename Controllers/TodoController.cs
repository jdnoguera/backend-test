using backend_test.Models;
using backend_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_test.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Todo>> Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public ActionResult<List<Todo>> AddTodo(CreateTodoModel model)
    {
        return Ok(_service.CreateTodo(model));
    }

    [HttpDelete]
    public ActionResult<List<Todo>> Delete()
    {
        _service.DeleteAll();
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<List<Todo>> DeleteById(string id)
    {
        if (_service.DeleteById(id))
        {
           return Ok();
        }

        return NotFound("No se encontro el id");
    }
 }