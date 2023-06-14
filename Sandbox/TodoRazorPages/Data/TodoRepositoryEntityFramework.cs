namespace TodoRazorPages.Data
{
    public class TodoRepositoryEntityFramework : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepositoryEntityFramework(TodoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Todo> GetAll()
        {
            return _dbContext.Todos;
        }

        public Todo? GetById(Guid id) => _dbContext.Todos.Find(id);

        public void Add(Todo todo)
        {
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
        }

        public void Update(Guid id, Todo todo)
        {
            var existingTodo = _dbContext.Todos.Find(id);
            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.IsCompleted = todo.IsCompleted;
                _dbContext.SaveChanges();
            }
        }
    }
}
