using System.ComponentModel.DataAnnotations;

namespace TodoMvc.Models
{
    public class AddViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
