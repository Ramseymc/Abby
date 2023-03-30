using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Abby.Models.FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
            //Category = _db.Category.FirstOrDefault(u => u.Id == id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {       
   
            var foodTypeDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
            if (foodTypeDb != null)
            {
                _unitOfWork.FoodType.Remove(foodTypeDb);
                _unitOfWork.Save();
                TempData["success"] = "FoodType deleted succesfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
