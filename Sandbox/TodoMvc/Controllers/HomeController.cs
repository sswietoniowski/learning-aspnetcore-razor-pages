using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoMvc.Data;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITodoRepository todoRepository, ILogger<HomeController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var todos = _todoRepository.GetAll();

            return View(todos);
        }

        public IActionResult Add()
        {
            var model = new AddViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo
                {
                    Title = model.Title,
                    IsCompleted = model.IsCompleted
                };

                _todoRepository.Add(todo);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var todo = _todoRepository.GetById(id);

            if (todo == null)
            {
                return NotFound();
            }

            var model = new EditViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var todo = _todoRepository.GetById(id);

                if (todo == null)
                {
                    return NotFound();
                }

                todo.Title = model.Title;
                todo.IsCompleted = model.IsCompleted;

                _todoRepository.Update(id, todo);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}