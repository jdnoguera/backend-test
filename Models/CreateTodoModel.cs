using System.ComponentModel.DataAnnotations;

namespace backend_test.Models;

public class CreateTodoModel
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
}