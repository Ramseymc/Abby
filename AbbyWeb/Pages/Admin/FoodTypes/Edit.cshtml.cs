using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Abby.Models.FoodType FoodType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.Find(id);
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
        
            if (ModelState.IsValid)
            {   
                _db.FoodType.Update(FoodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "FoodType updated succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
