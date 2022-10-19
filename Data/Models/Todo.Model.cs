namespace test_blazor.Data;
using System.ComponentModel.DataAnnotations;
public class TodoModel
{
    public string Id { get; set; } = string.Empty;
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; }
}