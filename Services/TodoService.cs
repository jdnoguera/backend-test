using backend_test.Models;

namespace backend_test.Services;

public class TodoService
{
    private readonly Dictionary<string, Todo> _todoList = new();

    public IEnumerable<Todo> GetAll()
    {
        return _todoList.Values;
    }

    public Todo CreateTodo(CreateTodoModel model)
    {
        var todo = new Todo()
        {
            Id = Guid.NewGuid().ToString(),
            Description = model.Name
        };
        _todoList.Add(todo.Id, todo);
        return todo;
    }

    public void DeleteAll()
    { 
        _todoList.Clear();
    }

    public bool DeleteById(string id)
    {
        if (!_todoList.ContainsKey(id))
        {
            return false;
        }
        _todoList.Remove(id);
        return true;
    } 
}