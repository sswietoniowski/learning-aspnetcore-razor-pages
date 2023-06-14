using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoRazorPages.Data;

namespace TodoRazorPages.Pages
{
    public class EditModel : PageModel
    {
        private readonly ITodoRepository _todoRepository;

        public Guid Id { get; set; }
        [BindProperty]
        public InputModel Input { get; set; } = default!;

        public EditModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult OnGet(Guid id)
        {
            var todo = _todoRepository.GetById(id);

            if (todo is null)
            {
                return NotFound();
            }

            Id = id;

            Input = new InputModel
            {
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };

            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var todo = new Todo
            {
                Title = Input.Title,
                IsCompleted = Input.IsCompleted
            };

            _todoRepository.Update(id, todo);

            return RedirectToPage("Index");
        }

        public class InputModel
        {
            public string Title { get; set; } = default!;
            public bool IsCompleted { get; set; }
        }
    }
}
