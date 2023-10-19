using Microsoft.AspNetCore.Mvc;
using MyNotes.Data;
using MyNotes.Entities;
using MyNotes.Models;

namespace MyNotes.Controllers
{
    public class NoteController : Controller
    {

        private readonly Context _context;
        private readonly NoteModel model;

        public NoteController(Context context, NoteModel model)
        {
            _context = context;
            this.model = model;
        }
        public IActionResult Index()
        {
            var blogPosts = _context.Notes.ToList();
            return View(blogPosts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Note post)
        {

            post.CreatedAt = DateTime.Now;
            _context.Notes.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int Id)
        {
            model.SelectedNote = _context.Notes.Find(Id);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(NoteModel model)
        {
            _context.Notes.Update(model.SelectedNote);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var note = _context.Notes.FirstOrDefault(b => b.Id == Id);

            //model.SelectedNote = note;

            _context.Notes.Remove(note);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            var note = _context.Notes.FirstOrDefault(b => b.Id == Id);
            if (note == null)
            {
                return NotFound();
            }

            model.SelectedNote = note;

            return View("Details", model);
        }
    }
}
