using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ICategoryRepository _dbCategory;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
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
                _dbCategory.Add(Category);
                _dbCategory.Save();
                TempData["success"] = "Category created succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
