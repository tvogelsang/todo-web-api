namespace TodoWebApi.Entity
{
    public class Todo
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
