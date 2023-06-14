namespace TodoMvc.Data
{
    public interface ITodoRepository
    {
        public IEnumerable<Todo> GetAll();
        public Todo? GetById(Guid id);
        public void Add(Todo todo);
        public void Update(Guid id, Todo todo);
    }
}
