using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Displays the list of to-do items
        public IActionResult Index() => View(_context.Historicos.ToList());

        #region Create

        // Displays the form to create a new to-do item
        public IActionResult Create()
        {
            return View();
        }

        // Handles the HTTP POST request to create a new Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Historico todo)
        {
            if (ModelState.IsValid)
            {
                _context.Historicos.Add(todo);
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
            var historico = _context.Historicos.FirstOrDefault(x => x.Id == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        #endregion

        #region Edit

        // Displays the form to edit a specific Author item
        public IActionResult Edit(int? id)
        {
            var historico = _context.Historicos.FirstOrDefault(x => x.Id == id);
            if (historico == null)
            {
                return NotFound();
            }
            return View(historico);
        }

        // Handles the HTTP POST request to edit a specific Author item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ToDo.Models.Historico historico)
        {

            if (ModelState.IsValid)
            {
                _context.Historicos.Update(historico);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        // Displays a confirmation page for deleting a specific to-do item
        public IActionResult Delete(int id)
        {


            var historico = _context.Historicos.FirstOrDefault(x => x.Id == id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);
        }

        // Handles the HTTP POST request to delete a specific to-do item
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {

            var historicos = _context.Historicos.FirstOrDefault(x => x.Id == id);
            if (historicos != null)
            {
                _context.Historicos.Remove(historicos);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}
