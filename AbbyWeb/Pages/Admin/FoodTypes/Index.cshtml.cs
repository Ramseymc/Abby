using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Abby.Models.FoodType> FoodTypes { get; set; }

        /// <summary>
        /// Dependancy inject the ApplicationDbContext file so that the db is connected
        /// </summary>
        /// <param name="db"></param>
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodTypes = _unitOfWork.FoodType.GetAll();
        }
    }
}
