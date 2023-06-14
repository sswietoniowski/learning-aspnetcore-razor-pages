using System.ComponentModel.DataAnnotations;

namespace TodoMvc.Models
{
    public class EditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
