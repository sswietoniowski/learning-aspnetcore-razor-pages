using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoRazorPages.Data;

namespace TodoRazorPages.Pages
{
    public class AddModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        [BindProperty]
        public InputModel Input { get; set; }

        public AddModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void OnGet()
        {
            Input = new InputModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var todo = new Data.Todo
            {
                Title = Input.Title,
                IsCompleted = Input.IsCompleted
            };

            _todoRepository.Add(todo);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            public string Title { get; set; } = default!;
            public bool IsCompleted { get; set; }
        }
    }
}
