using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Notes
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Note Note { get; set; }

        public EditModel(ApplicationDbContext db)
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
   
            if (ModelState.IsValid)
            {
                //Category.Id = 
                _db.Note.Update(Note);
                await _db.SaveChangesAsync();
                TempData["success"] = "Note updated succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
