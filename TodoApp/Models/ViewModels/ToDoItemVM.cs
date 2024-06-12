namespace TodoApp.Models.ViewModels;

public class ToDoItemVM
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime ExpireDateTime { get; set; }
    public string? UserId { get; set; }
}