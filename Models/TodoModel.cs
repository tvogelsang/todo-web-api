namespace TodoWebApi.Models
{
    public class TodoModel
    {
        public bool Completed { get; set; } = false;
        public string Title { get; set; } = String.Empty;
    }
}
