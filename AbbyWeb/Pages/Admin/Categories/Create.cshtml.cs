using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "You cannot have the exact same Name and Display Order");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
