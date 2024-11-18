using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Displays the list of to-do items
        public IActionResult Index() => View(_context.Authors.ToList());

        #region Create

        // Displays the form to create a new to-do item
        public IActionResult Create()
        {
            return View();
        }

        // Handles the HTTP POST request to create a new Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author todo)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(todo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(todo);
        }

        #endregion

        #region Details

        // Displays details of a specific Author item
        public IActionResult Details(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        #endregion

        #region Edit

        // Displays the form to edit a specific Author item
        public IActionResult Edit(int? id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Handles the HTTP POST request to edit a specific Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDo.Models.Author author)
        {

            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        // Displays a confirmation page for deleting a specific to-do item
        public IActionResult Delete(int id)
        {


            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // Handles the HTTP POST request to delete a specific to-do item
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {

            var authors = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (authors != null)
            {
                _context.Authors.Remove(authors);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
