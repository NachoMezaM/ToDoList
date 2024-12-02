using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Displays the list of to-do items
        public IActionResult Index() => View(_context.Productos.ToList());

        #region Create

        // Displays the form to create a new to-do item
        public IActionResult Create()
        {
            return View();
        }

        // Handles the HTTP POST request to create a new Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto todo)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(todo);
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
            var producto = _context.Productos.FirstOrDefault(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        #endregion

        #region Edit

        // Displays the form to edit a specific Author item
        public IActionResult Edit(int? id)
        {
            var producto = _context.Productos.FirstOrDefault(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // Handles the HTTP POST request to edit a specific Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDo.Models.Producto producto)
        {

            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        // Displays a confirmation page for deleting a specific to-do item
        public IActionResult Delete(int id)
        {


            var producto = _context.Productos.FirstOrDefault(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // Handles the HTTP POST request to delete a specific to-do item
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {

            var productos = _context.Productos.FirstOrDefault(x => x.Id == id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
