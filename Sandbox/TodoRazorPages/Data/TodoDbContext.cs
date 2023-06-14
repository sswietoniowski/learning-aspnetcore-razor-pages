using Microsoft.EntityFrameworkCore;

namespace TodoRazorPages.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(t => t.Id);
            modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Todo>().Property(t => t.IsCompleted).IsRequired();

            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = new System.Guid("00000000-0000-0000-0000-000000000001"), Title = "Todo 1", IsCompleted = false },
                new Todo { Id = new System.Guid("00000000-0000-0000-0000-000000000002"), Title = "Todo 2", IsCompleted = false },
                new Todo { Id = new System.Guid("00000000-0000-0000-0000-000000000003"), Title = "Todo 3", IsCompleted = false }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
