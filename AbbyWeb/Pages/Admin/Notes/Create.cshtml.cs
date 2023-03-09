using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Notes
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Note Note { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
         
            if (ModelState.IsValid)
            {
                await _db.Note.AddAsync(Note);
                await _db.SaveChangesAsync();
                TempData["success"] = "Note created succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
