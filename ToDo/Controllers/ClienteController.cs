using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Displays the list of to-do items
        public IActionResult Index() => View(_context.Clientes.ToList());

        #region Create

        // Displays the form to create a new to-do item
        public IActionResult Create()
        {
            return View();
        }

        // Handles the HTTP POST request to create a new Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente todo)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(todo);
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
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        #endregion

        #region Edit

        // Displays the form to edit a specific Author item
        public IActionResult Edit(int? id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // Handles the HTTP POST request to edit a specific Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDo.Models.Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        // Displays a confirmation page for deleting a specific to-do item
        public IActionResult Delete(int id)
        {


            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Handles the HTTP POST request to delete a specific to-do item
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {

            var clientes = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
