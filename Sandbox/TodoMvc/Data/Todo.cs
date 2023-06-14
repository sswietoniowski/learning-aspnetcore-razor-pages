using System.ComponentModel.DataAnnotations;

namespace TodoMvc.Data
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
