using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Notes
{
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Note Note { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Note = _db.Note.Find(id);
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {       
   
            var NoteFromDb = _db.Note.Find(Note.Id);
            if (NoteFromDb != null)
            {
                _db.Note.Remove(NoteFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Note deleted succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
