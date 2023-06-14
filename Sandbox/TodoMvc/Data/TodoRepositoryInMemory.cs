namespace TodoMvc.Data
{
    public class TodoRepositoryInMemory : ITodoRepository
    {
        private readonly List<Todo> _todos = new()
        {
            new Todo { Id = Guid.NewGuid(), Title = "Learn ASP.NET Core", IsCompleted = true },
            new Todo { Id = Guid.NewGuid(), Title = "Build awesome apps", IsCompleted = false },
        };

        public IEnumerable<Todo> GetAll() => _todos;

        public Todo? GetById(Guid id) => _todos.FirstOrDefault(x => x.Id == id);

        public void Add(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            _todos.Add(todo);
        }

        public void Update(Guid id, Todo todo)
        {
            var index = _todos.FindIndex(x => x.Id == id);

            if (index != -1)
            {
                _todos[index] = todo;
            }
        }
    }
}
