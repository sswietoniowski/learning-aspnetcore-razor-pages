using Dapper;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace TodoRazorPages.Data
{
    public class TodoRepositoryDapper : ITodoRepository
    {
        private readonly string _connectionString;

        public TodoRepositoryDapper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TodoConnectionString");
        }

        public IEnumerable<Todo> GetAll()
        {
            using var connection = new SQLiteConnection(_connectionString);

            return connection.Query<Todo>("SELECT Id, Title, IsCompleted FROM Todos");
        }

        public Todo? GetById(Guid id)
        {
            using var connection = new SQLiteConnection(_connectionString);

            var todo = connection.QuerySingleOrDefault<Todo>("SELECT Id, Title, IsCompleted FROM Todos WHERE Id = @Id", new { Id = id });

            return todo;
        }

        public void Add(Todo todo)
        {
            using var connection = new SQLiteConnection(_connectionString);

            todo.Id = Guid.NewGuid();

            connection.Execute("INSERT INTO Todos (Id, Title, IsCompleted) VALUES (@Id, @Title, @IsCompleted)", todo);
        }

        public void Update(Guid id, Todo todo)
        {
            using var connection = new SQLiteConnection(_connectionString);

            connection.Execute("UPDATE Todos SET Title = @Title, IsCompleted = @IsCompleted WHERE Id = @Id", new { Id = id, todo.Title, todo.IsCompleted });
        }
    }
}
