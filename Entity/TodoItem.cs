namespace TodoWebApi.Entity
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Completed { get; set; }
        public string Title { get; set; } = String.Empty;
    }
}
