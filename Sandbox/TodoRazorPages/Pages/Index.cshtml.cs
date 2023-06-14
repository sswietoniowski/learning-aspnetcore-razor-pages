using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoRazorPages.Data;

namespace TodoRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Todo> Todos = new List<Todo>();

        public IndexModel(ITodoRepository todoRepository, ILogger<IndexModel> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        public void OnGet()
        {
            Todos = _todoRepository.GetAll();
        }
    }
}